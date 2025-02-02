using Aban360.Api.Controllers.V1;
using Microsoft.AspNetCore.Mvc;
using SmsHub.Domain.BaseDomainEntities.ApiResponse;

namespace SmsHub.Api.Controllers.Temp
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class TempController : BaseController
    {
        [HttpPost]
        [Route("location/descriptive")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<DescriptiveLocationDto>), StatusCodes.Status200OK)]
        public IActionResult GetLocations([FromBody]SearchInput searchInput)
        {
            var output = new DescriptiveLocationDto()
            {
                //CountryTitle="ایران",
                CordinalDirectionTitle="بخش مرکزی",
                Headquarters= "شرکت آبفا استان اصفهان",
                ProvinceTitle="استان اصفهان",
                RegionTitle="شهر اصفهان",
                ZoneTitle="منطقه سه",
                MunicipalityTitle="شهرداری منطقه 14"
            };
            return Ok(output);
        }

        [HttpPost]
        [Route("subscription/summary")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<SubscriptionSummaryDto>), StatusCodes.Status200OK)]
        public IActionResult GetSummary([FromBody] SearchInput searchInput)
        {
            var output = new SubscriptionSummaryDto()
            {
                Address = "خیابان چهارباغ- کوچه بیست و دوم- پلاک یازدهم",
                BranchState = "متصل به شبکه",
                CommercialUnitSewage = 0,
                CommercialUnitWater = 1,
                ConsumtionClass = "پر مصرف",
                ContractualCapacity = 4,
                DebtAmount = "تسویه شده",
                DomesticUnitSewage = 1,
                DomesticUnitWater = 1,
                EmptyUnit = 2,
                FirstName = "حمیدرضا",
                FullName = "حمیدرضا رضایی",
                HouseholdUnit = 5,
                InstallaionDayWater = "1400/01/01",
                RequestDayWater = "1399/12/18",
                SureName = "رضایی",
                SubscriptionDay = "1400/01/14",
                Tags = new string[] { "اکالیپتوس", "سگ نگهبان", "دارای بار آلایندگی" },
                UsageTitle = "مسکونی",
                WaterMeterState = "سالم",
                BranchStateColor = "green",
                WaterMeterStateColor = "blue",
                ConsumptionClassColor = "red"
            };
            return Ok(output);
        }

        [HttpPost]
        [Route("individual/owner")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<Individual>), StatusCodes.Status200OK)]
        public IActionResult GetOwner([FromBody]SearchInput searchInput)
        {
            var output = new List<Individual>()
            {
                new Individual() {Id=5, FatherName="علی", FirstName="نسترن",FullName="نسترن کریمی",MobileNumber="09130000000",NationalId="1270123456",PhoneNumber="031-31234567",SureName="کریمی" },
                new Individual() {Id=6, FatherName="رضا", FirstName="آرمان",FullName="آرمان کریمی",MobileNumber="09130000001",NationalId="1270123456",PhoneNumber="031-31234567",SureName="کریمی" }
            };
            return Ok(output);
        }

        [HttpPost]
        [Route("individual/stakeholder")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<ICollection<Individual>>), StatusCodes.Status200OK)]
        public IActionResult GetStakeholder([FromBody] SearchInput searchInput)
        {
            var output = new List<Individual>()
            {
                new Individual() {Id=1, FatherName="علی", FirstName="نسترن",FullName="نسترن کریمی",MobileNumber="09130000000",NationalId="1270123456",PhoneNumber="031-31234567",SureName="کریمی" },
                new Individual() {Id=2, FatherName="رضا", FirstName="آرمان",FullName="آرمان کریمی",MobileNumber="09130000001",NationalId="1270123456",PhoneNumber="031-31234567",SureName="کریمی" }
            };
            return Ok(output);
        }

        [HttpPost]
        [Route("realm/estate")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<Estate>), StatusCodes.Status200OK)]
        public IActionResult GetEstate([FromBody] SearchInput input)
        {
            var output = new Estate()
            {
                Id=1,
                Improvements = 120,
                Premises = 180,
                X = 32.2566554,
                Y = 56.98455471
            };
            return Ok(output);
        }

        [HttpPost]
        [Route("realm/flat")]
        [ProducesResponseType(typeof(ApiResponseEnvelope<ICollection<Flat>>), StatusCodes.Status200OK)]
        public IActionResult GetFlat([FromBody] SearchInput input)
        {
            var output = new Flat()
            {
                Id=1,
                Storey = 2
            };
            return Ok(output);
        }

        [HttpPost]
        [Route("network/water-meter")]
        public IActionResult GetWaterMeters([FromBody] SearchInput input)
        {
            var output = new List<WaterMeter>()
            {
                new WaterMeter()
                {
                    Id=1,
                    Serial = "12346788",
                    CategoryTitle = "اصلی",
                    ChangeReasonTitle = "شکستگی",
                    DiameterTitle = "1/2 اینچ",
                    InstallationDay = "1403/05/21"
                },
                new WaterMeter()
                {
                    Id=2,
                    Serial = "12346789",
                    CategoryTitle = "فرعی",
                    ChangeReasonTitle = "",
                    DiameterTitle = "1/4 اینچ",
                    InstallationDay = "1403/10/18"
                }
            };
            return Ok(output);  
        }

        [HttpPost]
        [Route("network/shiphon")]
        public IActionResult GetSiphons([FromBody] SearchInput input)
        {
            var output = new List<Siphon>()
            {
                new Siphon()
                {
                    Id=1,
                    CategoryTitle = "اصلی",
                    DiameterTitle = "1 اینچ",
                    InstallationDay = "1403/01/01",
                    Model = "خشک"
                },
                new Siphon 
                {
                    Id = 2,
                    CategoryTitle = "فرعی",
                    DiameterTitle = "1/2 اینچ",
                    InstallationDay = "1403/01/09",
                    Model = "غیر خشک"
                }
            };
            return Ok(output);
        }
    }

    public class Siphon
    {
        public long Id { get; set; }
        public string CategoryTitle { get; set; }
        public string DiameterTitle { get; set; }
        public string InstallationDay { get; set; }
        public string Model { get; set; }
    }
    public class WaterMeter
    {
        public long Id { get; set; }
        public string CategoryTitle { get; set; }
        public string Serial { get; set; }
        public string DiameterTitle { get; set; }
        public string ChangeReasonTitle { get; set; }
        public string InstallationDay { get; set; }
    }
    public class Flat
    {
        public long Id { get; set; }
        public int Storey { get; set; }
    }
    public class Estate
    {
        public long Id { get; set; }
        public float Premises { get; set; }// arse
        public float Improvements { get; set; }// aian
        public double X { get; set; }
        public double Y { get; set; }

    }
    public class Individual
    {
        public long Id { get; set; }
        public string FirstName { get; set; }
        public string SureName { get; set; }
        public string FullName { get; set; }
        public string FatherName { get; set; }
        public string NationalId { get; set; }
        public string MobileNumber { get; set; }
        public string PhoneNumber { get; set; }
    }
    public class SubscriptionSummaryDto
    {
        public string FirstName { get; set; }
        public string SureName { get; set; }
        public string FullName { get; set; }
        public string Address { get; set; }
        public string DebtAmount { get; set; }
        public string ConsumtionClass { get; set; }
        public string BranchState { get; set; }
        public string WaterMeterState { get; set; }
        public int DomesticUnitWater { get; set; }
        public int DomesticUnitSewage { get; set; }
        public int CommercialUnitWater { get; set; }
        public int CommercialUnitSewage { get; set; }
        public int OtherUnitWater { get; set; }
        public int OtherUnitSewage { get; set; }
        public int EmptyUnit { get; set; }
        public int HouseholdUnit { get; set; }
        public ICollection<string> Tags { get; set; }
        public string UsageTitle { get; set; }
        public float ContractualCapacity { get; set; }
        public string SubscriptionDay { get; set; }
        public string RequestDayWater { get; set; }
        public string RequestDaySewage { get; set; }
        public string InstallaionDayWater { get; set; }
        public string InstallationDaySewage { get; set; }
        public string BranchStateColor { get; set; }
        public string WaterMeterStateColor { get; set; }
        public string ConsumptionClassColor { get; set; }
    }
    public class DescriptiveLocationDto
    {
       // public string CountryTitle { get; set; } = default!;
        public string CordinalDirectionTitle { get; set; } = default!;
        public string Headquarters { get; set; } = default!;
        public string ProvinceTitle { get; set; } = default!;
        public string RegionTitle { get; set; } = default!;
        public string ZoneTitle { get; set; } = default!;
        public string MunicipalityTitle { get; set; } = default!;
    }
    public class SearchInput
    {
        public string Input { get; set; } = default!;
    }
}
