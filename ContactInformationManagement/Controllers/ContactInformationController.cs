using ContactInformationManagement.Business.Repository.ContactInformation;
using ContactInformationManagement.Common.DTO;
using ContactInformationManagement.Common.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactInformationManagement.Controllers
{
    [Route("api/contact")]
    [ApiController]
    public class ContactInformationController : ControllerBase
    {
        private readonly IContactInformationRepository _contactInformationRepository;

        public ContactInformationController(IContactInformationRepository contactInformationRepository)
        {
            this._contactInformationRepository = contactInformationRepository;
        }

        [HttpGet]
        public IActionResult GetAllContactDetail()
        {
            try
            {
                var contactDetails = _contactInformationRepository.GetAllContactDetails();

                return Ok(contactDetails.Select(item => new ContactDetailDTO()
                {
                    ContactDetailId = item.ContactDetailId,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Email = item.Email,
                    PhoneNumber = item.PhoneNumber,
                    Status = item.Status.ToString()
                }));

            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetContactDetail([FromRoute] int id)
        {
            try
            {
                var contactDetails = _contactInformationRepository.GetContactDetailById(id);
                var contactDetailDTO = new ContactDetailDTO();

                if (contactDetails != null)
                {
                    contactDetailDTO.ContactDetailId = id;
                    contactDetailDTO.FirstName = contactDetails.FirstName;
                    contactDetailDTO.LastName = contactDetails.LastName;
                    contactDetailDTO.Email = contactDetails.Email;
                    contactDetailDTO.PhoneNumber = contactDetails.PhoneNumber;
                    contactDetailDTO.Status = contactDetails.Status.ToString();
                }
                return Ok(contactDetailDTO);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }


        [HttpPost]
        public IActionResult Save([FromBody] ContactDetailDTO contactDetailDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                Status status;
                var contactDetail = new Common.Model.ContactDetail();
                contactDetail.Email = contactDetailDTO.Email;
                contactDetail.FirstName = contactDetailDTO.FirstName;
                contactDetail.LastName = contactDetailDTO.LastName;
                contactDetail.PhoneNumber = contactDetailDTO.PhoneNumber;
                Enum.TryParse<Status>(contactDetailDTO.Status, out status);
                contactDetail.Status = status;
               var newContactDetail = _contactInformationRepository.Add(contactDetail);

                return Ok(new { Message = "Contact information added successfully",ContactId = newContactDetail.ContactDetailId });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }



        [HttpPut("Update/{id}")]
        public IActionResult Update([FromRoute] int id, [FromBody] ContactDetailDTO contactDetailDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                if (contactDetailDTO.ContactDetailId.HasValue && id != contactDetailDTO.ContactDetailId.Value)
                {
                    return BadRequest(new { Message = "Missmatch in the contact detail id in request" });
                }

                var contact = _contactInformationRepository.GetContactDetailById(id);
                if (contact == null)
                    return BadRequest(new { Message = "Contact information not present for passed contact detail id" });

                Status status;
                contact.Email = contactDetailDTO.Email;
                contact.FirstName = contactDetailDTO.FirstName;
                contact.LastName = contactDetailDTO.LastName;
                contact.PhoneNumber = contactDetailDTO.PhoneNumber;
                Enum.TryParse<Status>(contactDetailDTO.Status, out status);
                contact.Status = status;
                _contactInformationRepository.Update(contact);

                return Ok(new { Message = "Contact information updated successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }


        [HttpDelete("{id}")]
        public IActionResult DeleteContactDetail([FromRoute] int id)
        {
            try
            {
                _contactInformationRepository.Delete(id);

                return Ok(new { Message = "Contact information deleted successfully" });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }

    }
}
