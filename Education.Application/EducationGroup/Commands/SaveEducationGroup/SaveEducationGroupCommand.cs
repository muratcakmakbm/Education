using Education.Application.EducationGroup.Dto;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Education.Application.EducationGroup.Commands.SaveEducationGroup
{
    public class SaveEducationGroupCommand : CommandBase, IRequest<SaveEducationGroupCommandResult>
    {
        public SaveEducationGroupCommand()
        {
            Educations = new List<EducationDto>();
        }
        public int? EducationGroupId { get; set; }
        public string EducationGroupName { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? Status { get; set; }
        public List<EducationDto> Educations { get; set; }

        public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            var validationResults = new List<ValidationResult>();

            if (string.IsNullOrEmpty(EducationGroupName))
            {
                validationResults.Add(new ValidationResult("Eğitim grubu adını giriniz."));
            }

            if (!StartDate.HasValue)
            {
                validationResults.Add(new ValidationResult("Başlangıç tarihini giriniz."));
            }

            if (!EndDate.HasValue)
            {
                validationResults.Add(new ValidationResult("Bitiş tarihini giriniz."));
            }

            if (!Status.HasValue)
            {
                validationResults.Add(new ValidationResult("Statü bilgisini giriniz giriniz."));
            }

            if (Educations.Any())
            {
                if (Educations.Any(i => string.IsNullOrEmpty(i.EducationName)))
                {
                    validationResults.Add(new ValidationResult("Eğitim açıklamasını giriniz."));
                }

                if (Educations.Any(i => string.IsNullOrEmpty(i.EducationLink)))
                {
                    validationResults.Add(new ValidationResult("Eğitim linkini giriniz."));
                }
            }
            return validationResults;
        }


        //public override void Validate()
        //{
        //    if (string.IsNullOrEmpty(EducationGroupName))
        //        throw new Exception("Lütfen Eğitim Grubu Adını Giriniz.");

        //    if (string.IsNullOrEmpty(EducationGroupName))
        //        throw new Exception("Lütfen Eğitim Grubu Adını Giriniz.");

        //    if (string.IsNullOrEmpty(EducationGroupName))
        //        throw new Exception("Lütfen Eğitim Grubu Adını Giriniz.");

        //    if (string.IsNullOrEmpty(EducationGroupName))
        //        throw new Exception("Lütfen Eğitim Grubu Adını Giriniz.");
        //    base.Validate();
        //}
    }
}
