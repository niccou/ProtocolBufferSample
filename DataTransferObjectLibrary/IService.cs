using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataTransferObjectLibrary
{
    [System.ServiceModel.ServiceContract]
    public interface IService
    {
        [System.ServiceModel.OperationContract]
        int InsertPerson(Person person);

        [System.ServiceModel.OperationContract]
        int UpdatePerson(Person person);
        
        [System.ServiceModel.OperationContract]
        int DeletePerson(int personId);

        [System.ServiceModel.OperationContract]
        Person GetPersonById(int personId);

        [System.ServiceModel.OperationContract]
        ListOfPerson GetAllPerson();
    }
}
