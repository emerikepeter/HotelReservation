using HotelReservation.Data;
using HotelReservation.Models;
using HotelReservation.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace HotelReservation.Controllers
{
    [Authorize]
    [AutoValidateAntiforgeryToken]
    public class ReservationController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ReservationController(ApplicationDbContext context)
        {
            _context = context;
        }
        
        // GET: ReservationController/Details/5
        [HttpGet]
        public ActionResult CreateReservation()
        {
            return View();
        }

        // HttpPost: ReservationController/Create
        [HttpPost]
        public async Task<ActionResult> CreateReservation(ReservationViewModel model)
        {
            try
            {
                Random random = new Random();
                int randomNumber = random.Next(200000, 990000);
                string UniqueId = DateTime.Now.ToString("yy") + randomNumber;
                string _ReservationId = "R" + UniqueId;

                if (ModelState.IsValid)
                {
                    ReservationModel formData = new ReservationModel
                    {
                        ReservationId = _ReservationId,
                        FullName = model.FullName,
                        Destination = model.Destination,
                        HotelRooms = model.HotelRooms,
                        DateTravel = model.DateTravel,
                        DateRegistered = DateTime.Now,
                    };

                    _context.Tbl_Reservation.Add(formData);
                    await _context.SaveChangesAsync();
                    ModelState.Clear();
                    ViewBag.Message = "Reservation booked successfully";

                    return View();
                }
            }
            catch (SqlException err) 
            {
                ViewBag.Message = "Error: " + err.Message;
                return View();
            }
            return View();
        }

        // GET: ReservationController/ManageReservation
        public async Task<ActionResult> ManageReservation()
        {
            try
            {
                var reservation = await _context.Tbl_Reservation.Where(M => M.IsDeleted == false).ToListAsync();
                return View(reservation);
            }
            catch (Exception) { throw; }
        }

        // GET: ReservationController/EditReservation
        [HttpGet]
        public async Task<ActionResult> EditReservation(string id)
        {
            try
            {
                var reservation = await _context.Tbl_Reservation.FirstOrDefaultAsync(M => M.ReservationId == id);
                ReservationViewModel viewModel = new ReservationViewModel
                {
                    ReservationId = reservation.ReservationId,
                    FullName = reservation.FullName,
                    Destination = reservation.Destination,
                    HotelRooms = reservation.HotelRooms,
                    DateTravel = reservation.DateTravel,
                };
                return View(viewModel);
            }
            catch (Exception) { throw; }
        }

        [HttpPost]
        public async Task<ActionResult> EditReservation(string id, ReservationViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var _res = await _context.Tbl_Reservation.FirstOrDefaultAsync(M => M.ReservationId == id);
                    if (_res != null)
                    {
                        _res.FullName = model.FullName;
                        _res.Destination = model.Destination;
                        _res.HotelRooms = model.HotelRooms;
                        _res.DateTravel = model.DateTravel;
                        _res.DateRegistered = DateTime.Now;

                        _context.Tbl_Reservation.Update(_res);
                        await _context.SaveChangesAsync();
                        ModelState.Clear();
                    }
                    return RedirectToAction("ManageReservation");
                }
                return View();
            }
            catch (Exception) { throw; }
        }

        // GET: ReservationController/Delete/5
        public async Task<ActionResult> DeleteReservation(string id)
        {
            try
            {
                var _res = await _context.Tbl_Reservation.FirstOrDefaultAsync(M => M.ReservationId == id);
                _res.IsDeleted = true;
                _context.Tbl_Reservation.Update(_res);
                await _context.SaveChangesAsync();

                return RedirectToAction("ManageReservation");
            }
            catch (Exception)
            {
                return RedirectToAction("ManageReservation");
            }
        }
    }
}
