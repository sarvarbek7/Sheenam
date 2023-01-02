// ---------------------------------------------------------------
// Copyright (c) Coalition of the Good-Hearted Engineers
// FREE TO USE AS LONG AS SOFTWARE FUNDS ARE DONATED TO THE POOR
// ---------------------------------------------------------------


using Microsoft.AspNetCore.Mvc;
using RESTFulSense.Controllers;
using Sheenam.Core.Api.Models.Guests;
using Sheenam.Core.Api.Models.Guests.Exceptions;
using Sheenam.Core.Api.Services.Foundation.Guests;

namespace Sheenam.Core.Api.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class GuestsController : RESTFulController
    {
        private readonly IGuestService guestService;

        public GuestsController(IGuestService guestService) =>
            this.guestService = guestService;
        

        [HttpPost]
        public async ValueTask<ActionResult<Guest>> PostGuestAsync(Guest guest)
        {
            try
            {
                Guest postedGuest = 
                    await this.guestService.AddGuestAsync(guest);

                return Created(postedGuest);
            }
            catch (GuestValidationException guestsValidationException) 
            {
                return BadRequest(guestsValidationException.InnerException);
            }
            catch (GuestDependencyValidationException guestDependencyValidationException)
                when(guestDependencyValidationException.InnerException is AlreadyExistGuestException)
            {
                return Conflict(guestDependencyValidationException.InnerException);
            }
            catch (GuestDependencyValidationException guestDependencyValidationException)
            {
                return InternalServerError(guestDependencyValidationException.InnerException);
            }
            catch (GuestDependencyException guestDependencyException)
            {
                return InternalServerError(guestDependencyException.InnerException);
            }
            catch (GuestServiceException guestServiceException) 
            {
                return InternalServerError(guestServiceException.InnerException);
            }
        }
    }
}
