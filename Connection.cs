﻿using Microsoft.Win32;
using RentmanSharp.Endpoint;
using System.Collections.ObjectModel;

namespace RentmanSharp
{
    public class Connection
    {
        public string? Token { get; internal set; }
        private static Connection? instance;
        public static Connection Instance
        {
            get
            {
                if (instance == null)
                    instance = new Connection();
                return instance;
            }
        }

        private List<IEndpoint> endpoints= new List<IEndpoint>();
        public IReadOnlyList<IEndpoint> Endpoints { get => endpoints.AsReadOnly(); }

        private Connection()
        {
            this.findEndPoints();
        }

        public void Connect(in string token)
        {
            if (!string.IsNullOrWhiteSpace(Token))
                throw new NotSupportedException($"{nameof(Token)} already defined");
            if (string.IsNullOrWhiteSpace(token))
                throw new ArgumentException($"{nameof(token)} isn't valid");

            Token = token;
        }

        private void findEndPoints()
        {
            var type = typeof(IEndpoint);
            var types = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p) && !p.IsAbstract && !p.IsInterface);
            foreach (var t in types)
                if (t.GetConstructors().Any(c => c.GetParameters().Count() == 0))
                {
                    IEndpoint? instance = (IEndpoint?)Activator.CreateInstance(t);
                    if (instance != null)
                        endpoints.Add(instance);
                }
        }
        public IEndpoint GetEndpoint(Type type)
        {
            if (this.endpoints == null)
                throw new NullReferenceException();
            var result = this.endpoints.FirstOrDefault(t => t.GetType() == type);
            if (result != null)
                return result;

            throw new NullReferenceException();
        }
    }
}