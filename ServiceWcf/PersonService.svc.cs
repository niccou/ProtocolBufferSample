using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace ServiceWcf
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "PersonService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select PersonService.svc or PersonService.svc.cs at the Solution Explorer and start debugging.
    public class PersonService : DataTransferObjectLibrary.IService
    {
        private static List<DataTransferObjectLibrary.Person> plist = new List<DataTransferObjectLibrary.Person>();

        public int InsertPerson(DataTransferObjectLibrary.Person person)
        {
            if (person == null)
                throw new ArgumentNullException("person");

            try
            {
                if (person.Id == -1)
                    person.Id = plist.Count > 0 ? plist.Select(p => p.Id).Max() + 1 : 0;

                plist.Add(person);

                return 1;
            }
            catch
            {
            }

            return 0;
        }

        public int UpdatePerson(DataTransferObjectLibrary.Person person)
        {
            DeletePerson(person.Id);
            return InsertPerson(person);
        }

        public int DeletePerson(int personId)
        {
            var person = plist.SingleOrDefault(p => p.Id == personId);

            if (person != null)
            {
                try
                {
                    plist.Remove(person);

                    return 1;
                }
                catch
                {
                }
            }

            return 0;
        }

        public DataTransferObjectLibrary.Person GetPersonById(int personId)
        {
            return plist.SingleOrDefault(p => p.Id == personId);
        }

        DataTransferObjectLibrary.ListOfPerson DataTransferObjectLibrary.IService.GetAllPerson()
        {
            var result = new DataTransferObjectLibrary.ListOfPerson();

            foreach (var item in plist)
            {
                result.PersonList.Add(item);
            }

            return result;
        }
    }
}
