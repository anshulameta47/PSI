namespace Com.Sapient.Contracts.V1.Requests
{
    public class UserAnswerBody
    {
        public short SecurityQuestionId { get; set; }
        public string Answer { get; set; }
    }
}
