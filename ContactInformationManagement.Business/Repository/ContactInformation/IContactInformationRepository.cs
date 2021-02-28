using ContactInformationManagement.Common.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactInformationManagement.Business.Repository.ContactInformation
{
    public interface IContactInformationRepository
    {

        ContactDetail Add(ContactDetail contactDetail);
        void Update(ContactDetail contactDetail);
        void Delete(int contactDetailId);
        ContactDetail GetContactDetailById(int contactDetailId);
        ContactDetail[] GetAllContactDetails();
    }
}
