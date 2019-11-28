using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace MagicEightBallService
{
    [ServiceContract]
    public interface IEightBall
    {
        [OperationContract]
        string ObtainAnswerToQuestion(string userQuestion);
    }
}
