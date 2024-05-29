using Common.CrossCutting.Enums;

namespace Common.CrossCutting.Dtos
{
    public class CrudOperationResult<TDto>
    {
        public CrudOperationResultStatus Status { get; set; }

        public TDto? Result { get; set; }
    }
}
