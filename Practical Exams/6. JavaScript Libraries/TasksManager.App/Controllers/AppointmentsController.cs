using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.ValueProviders;
using TasksManager.App.AuthenticationHeaders;
using TasksManager.App.Models;
using TasksManager.Data;

namespace TasksManager.App.Controllers
{
    public class AppointmentsController : BaseApiController
    {
        public AppointmentsController()
        {
            using (var context = new TasksManagerDbContext())
            {
                var finishedState = context.States.FirstOrDefault(st => st.Value == "finished");
                var currentState = context.States.FirstOrDefault(st => st.Value == "current");
                var appointments = context.Appointments;
                foreach (var app in appointments)
                {
                    if (app.AppointmentDate <= DateTime.Now)
                    {
                        var from = app.AppointmentDate;
                        var to = app.AppointmentDate.AddMinutes(app.Duration);
                        if (from <= DateTime.Now && DateTime.Now <= to)
                        {
                            app.State = currentState;
                        }
                        else if (app.StateId != finishedState.Id)
                        {
                            app.State = finishedState;
                        }
                    }
                }
                context.SaveChanges();
            }
        }

        [HttpPost]
        [ActionName("new")]
        public HttpResponseMessage CreateAppointment(AppointmentModel model,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))]
            string accessToken)
        {
            return this.ExecuteOperationAndHandleExceptions(() =>
            {
                var context = new TasksManagerDbContext();
                var meUser = this.GetUserByAccessToken(accessToken, context);
                this.ValidateAppointment(model);
                var appointmentEntity = model.ToEntity();
                appointmentEntity.Owner = meUser;
                appointmentEntity.State = context.States.FirstOrDefault(st => st.Value == "upcomming");

                meUser.Appointments.Add(appointmentEntity);
                context.SaveChanges();
                var responseModel = new AppointmentCreatedModel()
                {
                    Id = appointmentEntity.Id,
                    Owner = appointmentEntity.Owner.Username
                };
                var response = this.Request.CreateResponse(HttpStatusCode.Created, responseModel);
                return response;
            });
        }

        [HttpGet]
        [ActionName("all")]
        public IQueryable<AppointmentModel> GetAll(
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))]
            string accessToken)
        {
            return this.ExecuteOperationAndHandleExceptions(() =>
            {
                var context = new TasksManagerDbContext();
                var meUser = this.GetUserByAccessToken(accessToken, context);
                var appointmentModels = meUser.Appointments
                                              .AsQueryable()
                                              .OrderByDescending(app => app.AppointmentDate)
                                              .Select(AppointmentModel.FromAppointment);
                return appointmentModels;
            });
        }

        [HttpGet]
        [ActionName("comming")]
        public IQueryable<AppointmentModel> GetAllUpcomming(
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))]
            string accessToken)
        {
            return this.GetAll(accessToken)
                       .Where(app => app.State == "upcomming");
        }

        [HttpGet]
        [ActionName("by-date")]
        public IQueryable<AppointmentModel> GetAllForADate(string date,
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))]
            string accessToken)
        {
            var appointmentDate = DateTime.Parse(date);

            return this.GetAll(accessToken)
                       .Where(app => DateTime.Parse(app.AppointmentDate).Day == appointmentDate.Day &&
                                     DateTime.Parse(app.AppointmentDate).Month == appointmentDate.Month &&
                                     DateTime.Parse(app.AppointmentDate).Year == appointmentDate.Year);
        }

        [HttpGet]
        [ActionName("today")]
        public IQueryable<AppointmentModel> GetAllForToday(
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))]
            string accessToken)
        {
            var now = DateTime.Now;
            return this.GetAll(accessToken)
                       .Where(app => DateTime.Parse(app.AppointmentDate).Day == now.Day &&
                                     DateTime.Parse(app.AppointmentDate).Month == now.Month &&
                                     DateTime.Parse(app.AppointmentDate).Year == now.Year);
        }

        [HttpGet]
        [ActionName("current")]
        public IQueryable<AppointmentModel> GetAllCurrent(
            [ValueProvider(typeof(HeaderValueProviderFactory<string>))]
            string accessToken)
        {
            return this.GetAll(accessToken)
                       .Where(app => app.State == "current");
        }

        private void ValidateAppointment(AppointmentModel model)
        {
            if (model == null ||
                string.IsNullOrEmpty(model.Subject) ||
                string.IsNullOrEmpty(model.Description) ||
                model.Duration <= 0 ||
                string.IsNullOrEmpty(model.AppointmentDate))
            {
                throw new ArgumentNullException("Invalid Appointment");
            }

            var date = DateTime.Parse(model.AppointmentDate);
            if (date < DateTime.Now)
            {
                throw new ArgumentNullException("Invalid Appointment Date");
            }
        }
    }
}