using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Login.Contracts.V1.Response
{
    public class SecutityQuestionsOfUser
    {
        public long UserId { get; set; }
        public List<short> SecurityQuestionIdList { get; set; }
    }
}
