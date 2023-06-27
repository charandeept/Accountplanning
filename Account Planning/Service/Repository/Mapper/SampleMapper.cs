using Com.ACSCorp.AccountPlanning.Service.Models.ServiceModels;
using Com.ACSCorp.AccountPlanning.Service.Repository.Models;

using System;
using System.Collections.Generic;
using System.Text;

namespace Com.ACSCorp.AccountPlanning.Service.Repository.Mapper
{
    public static class SampleMapper
    {
        public static SampleDTO GetSamleDTO(this Sample sample)
        {
            return new SampleDTO()
            {
                Id = sample.Id,
                Name = sample.Name,
                IsActive = !sample.IsDeleted,
                CreatedById = sample.CreatedById,
                CreatedOn = sample.CreatedOn,
                ModifiedById = sample.ModifiedById,
                ModifiedOn = sample.ModifiedOn
            };
        }

        public static Sample GetSample(this SampleDTO sampleDTO)
        {
            Sample sample = new Sample
            {
                Id = sampleDTO.Id,
                Name = sampleDTO.Name,
                IsDeleted = !sampleDTO.IsActive
            };

            MapMetadata(sampleDTO, sample);

            return sample;
        }

        public static List<SampleDTO> GetSampleDTOs(this List<Sample> samples)
        {
            List<SampleDTO> sampleDTOs = new List<SampleDTO>();
            foreach (Sample item in samples)
            {
                sampleDTOs.Add(item.GetSamleDTO());
            }
            return sampleDTOs;
        }

        private static void MapMetadata(SampleDTO sampleDTO, Sample sample)
        {
            sample.ModifiedOn = sampleDTO.ModifiedOn;
            sample.ModifiedById = sampleDTO.ModifiedById;
            sample.CreatedOn = sampleDTO.CreatedOn;
            sample.CreatedById = sampleDTO.CreatedById;
        }
    }
}