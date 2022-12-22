using RentmanSharp.Entity;

namespace RentmanSharp.Endpoint
{
    /// <summary>
    /// Project Request Equipment are equipment items linked to the Project Request. You can use this to add equipment items in a raw data format to the Project Request. The equipment items will be matched to the existing equipment items in the account when converting the Project Request into a Project in the Rentman interface.
    /// </summary>
    public class ProjectRequestEquipment : AbstractEndpoint<ProjectRequestEquipmentItem>
    {
        public override string Path { get => "projectrequestequipment"; }
    }
}