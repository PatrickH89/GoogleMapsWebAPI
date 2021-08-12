using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using GoogleMapsWebAPI.Interfaces;
using GoogleMapsWebAPI;
using GoogleMapsWebAPI.Models;

namespace GoogleMapsWebAPI.Services
{
    public class AddressDatabaseService : IAddressDatabaseService
    {
        //------------------------------------------------------------------
        // dependency injection: declaration
        private readonly AddressContext _addressContext;

        //------------------------------------------------------------------
        // dependency injection: initialization
        public AddressDatabaseService(AddressContext addressContext)
        {
            _addressContext = addressContext;
        }

        //------------------------------------------------------------------
        // returns all entries in the database
        public IEnumerable<AddressOutputModel> GetAddresses()
        {
            if (_addressContext.AddressOutputModel.Any())
            {
                return _addressContext.AddressOutputModel.ToArray();
            }
            return null;
        }

        //------------------------------------------------------------------
        // returns specific entry in database selected by id
        public AddressOutputModel SelectAddress(int id)
        {
            if (id <= 0)
            {
                return null;
            }
            return _addressContext.AddressOutputModel.FirstOrDefault(x => x.Id == id);
        }

        //------------------------------------------------------------------
        // inserts an entity in database
        public AddressOutputModel InsertAddress(AddressOutputModel newAddressParameter)
        {
            if (newAddressParameter == null)
            {
                return null;
            }
            EntityEntry<AddressOutputModel> dbAddressReturn = _addressContext.Add(newAddressParameter);
            _addressContext.SaveChanges();
            return dbAddressReturn.Entity;
        }

        //------------------------------------------------------------------
        // updates a specific entity in database selected by id
        public IEnumerable<AddressOutputModel> UpdateAddress(int id, AddressOutputModel addressUpdate)
        {
            if (addressUpdate == null)
            {
                return null;
            }
            AddressOutputModel dbAddressReturn = _addressContext.AddressOutputModel.FirstOrDefault(x => x.Id == id);

            if (dbAddressReturn == null)
            {
                return null;
            }
            dbAddressReturn.Country = addressUpdate.Country;
            dbAddressReturn.City = addressUpdate.City;
            dbAddressReturn.PostCode = addressUpdate.PostCode;
            dbAddressReturn.Street = addressUpdate.Street;
            dbAddressReturn.StreetNumber = addressUpdate.StreetNumber;
            dbAddressReturn.Longitude = addressUpdate.Longitude;
            dbAddressReturn.Latitude = addressUpdate.Latitude;
            _addressContext.SaveChanges();
            return _addressContext.AddressOutputModel.ToArray();
        }

        //------------------------------------------------------------------
        // deletes a specific entry in database selected by id 
        public AddressOutputModel DeleteAddress(int id)
        {
            if (id <= 0)
            {
                return null;
            }
            AddressOutputModel item = _addressContext.AddressOutputModel.FirstOrDefault(x => x.Id == id);

            if (item == null)
            {
                return null;
            }
            EntityEntry<AddressOutputModel> dbAddressReturn = _addressContext.AddressOutputModel.Remove(item);

            if (dbAddressReturn == null)
            {
                return null;
            }
            _addressContext.SaveChanges();
            return dbAddressReturn.Entity;
        }
    }     
}