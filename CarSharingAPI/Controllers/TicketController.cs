using CarSharingAPI.Data;
using CarSharingAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query.Internal;
using System.Reflection.Metadata.Ecma335;

namespace CarSharingAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TicketController : ControllerBase
    {
        private readonly CarSharingAPIDbContext _context;
        public TicketController(CarSharingAPIDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<List<Ticket>>> GetTicketList(int userId)
        {
            var tickets = await _context.Tickets
                .Where(t => t.UserId == userId)
                .ToListAsync();
            return tickets;
        }

        [HttpPost]
        public async Task<IActionResult> CreateTicket(TicketDTO ticketDTO)
        {
            var ticket = new Ticket()
            {
                Title = ticketDTO.Title,
                Description = ticketDTO.Description,
                StartingPosition = ticketDTO.StartingPosition,
                EndingPosition = ticketDTO.EndingPosition,
                Cost = ticketDTO.Cost,
                Date = ticketDTO.Date,
                UserId = ticketDTO.OwnerID
            };
            await _context.Tickets.AddAsync(ticket);
            await _context.SaveChangesAsync();
            return Ok(ticket);  
        }

        [HttpPut]
        [Route("{id:int}")]
        public async Task<IActionResult> UpdateTicket([FromRoute] int id, TicketDTO ticketDTO)
        {
           var ticket = _context.Tickets.Find(id);
            if(ticket !=  null)
            {
                ticket.Title = ticketDTO.Title;
                ticket.Description = ticketDTO.Description;
                ticket.Date = ticketDTO.Date;
                ticket.Cost = ticketDTO.Cost;
                ticket.StartingPosition = ticketDTO.StartingPosition;
                ticket.EndingPosition = ticketDTO.EndingPosition;
                ticket.PassengerId = ticketDTO.PassengerId;

                await _context.SaveChangesAsync();
                return Ok(ticket);
            }
            return NotFound();
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<IActionResult> GetTicket([FromRoute] int id)
        {
            var ticket = await _context.Tickets.FindAsync(id);
            if (ticket == null)
            {
                return NotFound();
            }
            return Ok(ticket);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<IActionResult> DeleteTicket([FromRoute] int id)
        {
            var ticket = await _context.Tickets.FindAsync(id);
            if (ticket != null)
            {
                _context.Tickets.Remove(ticket);
                await _context.SaveChangesAsync();
                return Ok(ticket);
            }
            return NotFound();
        }
    }
}
