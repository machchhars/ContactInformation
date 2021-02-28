using ContactInformationManagement.Common.Model;
using ContactInformationManagement.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContactInformationManagement.Business.Repository.ContactInformation
{
    public class ContactInformationRepository : IContactInformationRepository
    {
        private readonly ContactInformatonDbContext _contactInformatonDbContext;

        public ContactInformationRepository(ContactInformatonDbContext contactInformatonDbContext)
        {
            this._contactInformatonDbContext = contactInformatonDbContext;
        }
        public ContactDetail Add(ContactDetail contactDetail)
        {
            if (_contactInformatonDbContext.ContactDetails.FirstOrDefault(item => item.PhoneNumber == contactDetail.PhoneNumber || item.Email == contactDetail.Email) != null)
                throw new ApplicationException("PhoneNumber or Email is already present");

            _contactInformatonDbContext.Add(contactDetail);
            _contactInformatonDbContext.SaveChanges();
            return contactDetail;
        }

        public void Update(ContactDetail contactDetail)
        {
            if (_contactInformatonDbContext.ContactDetails.FirstOrDefault(item => (item.PhoneNumber == contactDetail.PhoneNumber || item.Email == contactDetail.Email) && contactDetail.ContactDetailId!=item.ContactDetailId) != null)
                throw new ApplicationException("PhoneNumber or Email is already present");

            var entity = _contactInformatonDbContext.ContactDetails.Attach(contactDetail);
            entity.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            _contactInformatonDbContext.SaveChanges();
        }

        public void Delete(int contactDetailId)
        {
            var contactDetail = GetContactDetailById(contactDetailId);
            if (contactDetail != null)
            {
                _contactInformatonDbContext.ContactDetails.Remove(contactDetail);
                _contactInformatonDbContext.SaveChanges();
            }
            else
                throw new Exception("Contact information not present for contact detail id: " + contactDetailId);
        }

        public ContactDetail GetContactDetailById(int contactDetailId)
        {
            return _contactInformatonDbContext.ContactDetails.Find(contactDetailId);
        }


        public ContactDetail[] GetAllContactDetails()
        {
            IQueryable<ContactDetail> contactDetails =  _contactInformatonDbContext.ContactDetails.AsQueryable();
            return contactDetails.ToArray();
        }

    }
}
