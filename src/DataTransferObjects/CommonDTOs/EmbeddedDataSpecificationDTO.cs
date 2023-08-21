namespace DataTransferObjects.CommonDTOs
{
    //TODO (jtikekar, 0000-00-00): support DataSpecificationContent
    public record class EmbeddedDataSpecificationDTO(ReferenceDTO dataSpecification) : IDTO;
}
