using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using Com.ACSCorp.AccountPlanning.Service.Repository.Models;
using System;
using System.Collections.Generic;


namespace Com.ACSCorp.AccountPlanning.Service.Repository.Mapper
{

	public class VendorMapper
	{
		public static VendorDTO GetVendorDTO(Vendor vendor)
		{
			return new VendorDTO()
			{
				//Id = vendor.Id,
				vendorName = vendor.Name,
				serviceType = vendor.Services
			};
		}

		public static Vendor GetVendor(VendorDTO vendorDTO)
		{
			return new Vendor()
			{
				//Id = vendorDTO.Id,
				Name = vendorDTO.vendorName,
				Services = vendorDTO.serviceType
			};
		}

		public static List<VendorDTO> GetVendorList(List<Vendor> vendorList)
		{
			List<VendorDTO> listOfVendors = new List<VendorDTO>();

			foreach (Vendor v in vendorList)
			{
				listOfVendors.Add(GetVendorDTO(v));
			}

			return listOfVendors;
		}
	}
}