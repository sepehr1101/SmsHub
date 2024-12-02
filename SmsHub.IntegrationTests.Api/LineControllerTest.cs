using SmsHub.Domain.BaseDomainEntities.ApiResponse;
using SmsHub.Domain.BaseDomainEntities.Id;
using SmsHub.Domain.Constants;
using SmsHub.Domain.Features.Line.MediatorDtos.Commands.Create;
using SmsHub.Domain.Features.Line.MediatorDtos.Commands.Delete;
using SmsHub.Domain.Features.Line.MediatorDtos.Commands.Update;
using SmsHub.Domain.Features.Line.MediatorDtos.Queries;
using System.Linq;

namespace SmsHub.IntegrationTests.Api
{
    [CollectionDefinition("ApiIntegrationTests", DisableParallelization = true)]
    public class LineControllerTest : BaseIntegrationTest
    {
        public LineControllerTest(_TestEnvironmentWebApplicationFactory factory)
            : base(factory)
        {
        }

        [Fact]
        public async void CreateLine_LineDto_ShouldCreateLine()
        {
            //Arrange
            var line = new CreateLineDto
            {
                ProviderId = ProviderEnum.Magfa,
                Credential = "{'Domain': '---', 'UserName': '---' , 'ClientSecret' : '---' }",
                Number = "120010"
            };

            //Act
            await PostAsync<CreateLineDto, CreateLineDto>("/Line/Create", line);

            //Assert
            Assert.True(true);
        }


        [Fact]
        public async void DeleteLine_LineDto_ShouldDeleteLine()
        {
            //Arrange
            var line = new CreateLineDto
            {
                ProviderId = ProviderEnum.Magfa,
                Number = "12001020",
                 Credential= "{'Domain': '---', 'UserName': '---' , 'ClientSecret' : '---' }"
            };
            await PostAsync<CreateLineDto, CreateLineDto>("/Line/Create", line);
            var lineData = await PostAsync<GetLineDto, ApiResponseEnvelope<ICollection<GetLineDto>>>("/Line/GetList", null);

            var deleteLine = new DeleteLineDto()
            {
                Id = lineData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id
            };

            //Act
            await PostAsync<DeleteLineDto, DeleteLineDto>("/Line/Delete", deleteLine);

            //Assert
            Assert.True(true);
        }


        [Fact]
        public async void UpdateLine_LineDto_ShouldUpdateLine()
        {
            //Arrange
            var line = new CreateLineDto
            {
                ProviderId = ProviderEnum.Magfa,
                Number = "120010124",
                Credential = "{'Domain': '---', 'UserName': '---' , 'ClientSecret' : '---' }"
            };
            await PostAsync<CreateLineDto, CreateLineDto>("/Line/Create", line);
            var lineData = await PostAsync<GetLineDto, ApiResponseEnvelope<ICollection<GetLineDto>>>("/Line/GetList", null);

            var updateLine = new UpdateLineDto()
            {
                Id = lineData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id,
                ProviderId = ProviderEnum.Magfa,
                Number = "Update Number",
                Credential = "{'Domain': '---', 'UserName': '---' , 'ClientSecret' : '---' }"
            };

            //Act
            await PostAsync<UpdateLineDto, UpdateLineDto>("/Line/Update", updateLine);

            //Assert
            Assert.True(true);
        }


        [Fact]
        public async void GetSingleLine_LineDto_ShouldGetSingleLine()
        {
            //Arrange
            var line = new CreateLineDto
            {
                ProviderId = ProviderEnum.Magfa,
                Number = "120010250",
                Credential = "{'Domain': '---', 'UserName': '---' , 'ClientSecret' : '---' }"
            };
            await PostAsync<CreateLineDto, CreateLineDto>("/Line/Create", line);
            var lineData = await PostAsync<GetLineDto, ApiResponseEnvelope<ICollection<GetLineDto>>>("/Line/GetList", null);

            var lineId = new IntId()
            {
                Id = lineData.Data.OrderByDescending(x => x.Id).FirstOrDefault().Id
            };

            //Act
            var singleLine = await PostAsync<IntId, ApiResponseEnvelope<GetLineDto>>("/Line/GetSingle", lineId);

            //Assert
            Assert.Equal(singleLine.Data.Id, lineId.Id);
        }


        [Fact]
        public async void GetListLine_LineDto_ShouldGetListLine()
        {
            //Arrange
            var lines = new List<CreateLineDto>()
            {
               new CreateLineDto() {ProviderId = Domain.Constants.ProviderEnum.Kavenegar,Credential ="{'apiKey': '---' }",Number = "11851"},
               new CreateLineDto() {ProviderId = Domain.Constants.ProviderEnum.Magfa,Credential ="{'Domain': '---', 'UserName': '---' , 'ClientSecret' : '---' }",Number = "151200"},
               new CreateLineDto() {ProviderId = Domain.Constants.ProviderEnum.Magfa,Credential = "{'Domain': '---', 'UserName': '---' , 'ClientSecret' : '---' }",Number = "10225"},
               new CreateLineDto() {ProviderId = Domain.Constants.ProviderEnum.Kavenegar,Credential ="{'apiKey': '---' }",Number = "15102"},
            };

            //Act
            foreach (var item in lines)
            {
                await PostAsync<CreateLineDto, CreateLineDto>("/Line/Create", item);
            }
            var lineList = await PostAsync<GetLineDto, ApiResponseEnvelope<ICollection<GetLineDto>>>("/Line/GetList", null);

            //Assert
            Assert.InRange(lineList.Data.Count, 4, 8);
        }


        /////Test Validation 
        ///// @"{'Domain': '---', 'UserName': '---' , 'ClientSecret' : '---' }"   --> Magfa
        //// /@"{'apiKey': '---' }"  --> Kave Negar
        [Fact]
        public async void MagfaProvider_EmptyClientSecret_ShouldFail()
        {
            //Arrange
            var line = new CreateLineDto
            {
                ProviderId = ProviderEnum.Magfa,
                Number = "123452",
                Credential = "{'Domain': '---', 'UserName': '---' , 'ClientSecret' : '' }",
            };

            //Act
            var result = await PostAsyncWithoutDeserialize<CreateLineDto>("/Line/Create", line);
            string[] exceptionString = { "احراز هویت", "خطا در اطلاعات ورودی" };
            var x = exceptionString.Any(x => result.Contains(x));

            //Assert
            Assert.True(x);
        }


        [Fact]
        public async void MagfaProvider_EmtpyUserNameAndClientSecret_ShouldFail()
        {
            //Arrange
            var line = new CreateLineDto
            {
                ProviderId = ProviderEnum.Magfa,
                Number = "1524",
                Credential = "{'Domain': '---', 'UserName': '' , 'ClientSecret' : '' }",
            };

            //Act
            var result = await PostAsyncWithoutDeserialize<CreateLineDto>("/Line/Create", line);
            string[] exceptionString = { "احراز هویت", "خطا در اطلاعات ورودی" };
            var x = exceptionString.Any(x => result.Contains(x));

            //Assert
            Assert.True(x);
        }


        [Fact]
        public async void MagfaProvider_EmtpyCredential_ShouldFail()
        {
            //Arrange
            var line = new CreateLineDto
            {
                ProviderId = ProviderEnum.Magfa,
                Number = "12055",
                Credential = "",
            };

            //Act
            var result = await PostAsyncWithoutDeserialize<CreateLineDto>("/Line/Create", line);
            string[] exceptionString = { "احراز هویت", "خطا در اطلاعات ورودی" };
            var x = exceptionString.Any(x => result.Contains(x));

            //Assert
            Assert.True(x);
        }


        [Fact]
        public async void MagfaProvider_NullCredential_ShouldFail()
        {
            //Arrange
            var line = new CreateLineDto
            {
                ProviderId = ProviderEnum.Magfa,
                Number = "2524651",
            };

            //Act
            var result = await PostAsyncWithoutDeserialize<CreateLineDto>("/Line/Create", line);
            string[] exceptionString = { "احراز هویت", "خطا در اطلاعات ورودی" };
            var x = exceptionString.Any(x => result.Contains(x));

            //Assert
            Assert.True(x);
        }


        [Fact]
        public async void MagfaProvider_NullCredentialAndProviderId_ShouldFail()
        {
            //Arrange
            var line = new CreateLineDto
            {
                Number = "1465451",
            };

            //Act
            var result = await PostAsyncWithoutDeserialize<CreateLineDto>("/Line/Create", line);
            string[] exceptionString = { "احراز هویت", "خطا در اطلاعات ورودی" };
            var x = exceptionString.Any(x => result.Contains(x));

            //Assert
            Assert.True(x);
        }


        [Fact]
        public async void MagfaProvider_NullLine_ShouldFail()
        {
            //Arrange
            var line = new CreateLineDto
            { };

            //Act
            var result = await PostAsyncWithoutDeserialize<CreateLineDto>("/Line/Create", line);
            string[] exceptionString = { "احراز هویت", "خطا در اطلاعات ورودی" };
            var x = exceptionString.Any(x => result.Contains(x));

            //Assert
            Assert.True(x);
        }


        [Fact]
        public async void MagfaProvider_NullProviderId_ShouldFail()
        {
            //Arrange
            var line = new CreateLineDto
            {
                Number = "546545",
                Credential = "{'Domain': '---', 'UserName': '---' , 'ClientSecret' : '---' }"
            };

            //Act
            var result = await PostAsyncWithoutDeserialize<CreateLineDto>("/Line/Create", line);
            string[] exceptionString = { "احراز هویت", "خطا در اطلاعات ورودی" };
            var x = exceptionString.Any(x => result.Contains(x));

            //Assert
            Assert.True(x);
        }

        [Fact]
        public async void MagfaProvider_EmptyNumberAndCredential_ShouldFail()
        {
            //Arrange
            var line = new CreateLineDto
            {
                ProviderId = ProviderEnum.Magfa,
                Number = "",
                Credential = ""
            };

            //Act
            var result = await PostAsyncWithoutDeserialize<CreateLineDto>("/Line/Create", line);
            string[] exceptionString = { "احراز هویت", "خطا در اطلاعات ورودی" };
            var x = exceptionString.Any(x => result.Contains(x));

            //Assert
            Assert.True(x);
        }


        [Fact]
        public async void MagfaProvider_NullNumberAndCredential_ShouldFail()
        {
            //Arrange
            var line = new CreateLineDto
            {
                ProviderId = ProviderEnum.Magfa,
            };

            //Act
            var result = await PostAsyncWithoutDeserialize<CreateLineDto>("/Line/Create", line);
            string[] exceptionString = { "احراز هویت", "خطا در اطلاعات ورودی" };
            var x = exceptionString.Any(x => result.Contains(x));

            //Assert
            Assert.True(x);
        }

        [Fact]
        public async void MagfaProvider_InValidDomainProp_ShouldFail()
        {
            //Arrange
            var line = new CreateLineDto
            {
                ProviderId = ProviderEnum.Magfa,
                Number = "0124812",
                Credential = "{'Domainn': '---', 'UserName': '---' , 'ClientSecret' : '---' }"
            };

            //Act
            var result = await PostAsyncWithoutDeserialize<CreateLineDto>("/Line/Create", line);
            string[] exceptionString = { "احراز هویت", "خطا در اطلاعات ورودی" };
            var x = exceptionString.Any(x => result.Contains(x));

            //Assert
            Assert.True(x);
        }


        [Fact]
        public async void MagfaProvider_InValidAllCredentialProp_ShouldFail()
        {
            //Arrange
            var line = new CreateLineDto
            {
                ProviderId = ProviderEnum.Magfa,
                Number = "312897",//Domain        //UserName         //ClientSecret    
                Credential = "{'Domainn': '---', 'UseName': '---' , 'Clientecret' : '---' }"
            };

            //Act
            var result = await PostAsyncWithoutDeserialize<CreateLineDto>("/Line/Create", line);
            string[] exceptionString = { "احراز هویت", "خطا در اطلاعات ورودی" };
            var x = exceptionString.Any(x => result.Contains(x));

            //Assert
            Assert.True(x);
        }


        [Fact]
        public async void MagfaProvider_InvalidCredentialByLowOneSingleQuotation_ShouldFail()
        {
            //Arrange
            var line = new CreateLineDto
            {
                ProviderId = ProviderEnum.Magfa,
                Number = "713289",    //'
                Credential = "{'Domain : '---', 'UserName': '---' , 'ClientSecret' : '---' }"
            };

            //Act
            var result = await PostAsyncWithoutDeserialize<CreateLineDto>("/Line/Create", line);
            string[] exceptionString = { "احراز هویت", "خطا در اطلاعات ورودی" };
            var x = exceptionString.Any(x => result.Contains(x));

            //Assert
            Assert.True(x);
        }


        [Fact]
        public async void MagfaProvider_InvalidCredentialByLowTwoSingleQuotation_ShouldFail()
        {
            //Arrange
            var line = new CreateLineDto
            {
                ProviderId = ProviderEnum.Magfa,
                Number = "2455513",  // '                         // '
                Credential = "{'Domain : '---', 'UserName': '---' , ClientSecret' : '---' }"
            };

            //Act
            var result = await PostAsyncWithoutDeserialize<CreateLineDto>("/Line/Create", line);
            string[] exceptionString = { "احراز هویت", "خطا در اطلاعات ورودی" };
            var x = exceptionString.Any(x => result.Contains(x));

            //Assert
            Assert.True(x);
        }


        [Fact]
        public async void MagfaProvider_InvalidCredentialByLowOneSingleQuotationAndNullNumber_ShouldFail()
        {
            //Arrange
            var line = new CreateLineDto
            {
                ProviderId = ProviderEnum.Magfa,
                Credential = "{'Domain : '---', 'UserName': '---' , ClientSecret' : '---' }"
            };                     // '                         // '

            //Act
            var result = await PostAsyncWithoutDeserialize<CreateLineDto>("/Line/Create", line);
            string[] exceptionString = { "احراز هویت", "خطا در اطلاعات ورودی" };
            var x = exceptionString.Any(x => result.Contains(x));

            //Assert
            Assert.True(x);
        }


        [Fact]
        public async void MagfaProvider_InvalidCredentialByAddOneSingleQuotation_ShouldFail()
        {
            //Arrange
            var line = new CreateLineDto
            {
                ProviderId = ProviderEnum.Magfa,
                Number = "187132",                      // ''      // '  
                Credential = "{'Domain': '---', 'UserName'': '---' , ClientSecret' : '---' }"
            };

            //Act
            var result = await PostAsyncWithoutDeserialize<CreateLineDto>("/Line/Create", line);
            string[] exceptionString = { "احراز هویت", "خطا در اطلاعات ورودی" };
            var x = exceptionString.Any(x => result.Contains(x));

            //Assert
            Assert.True(x);
        }


        [Fact]
        public async void MagfaProvider_InvalidCredentialByAddTwoSingleQuotation_ShouldFail()
        {
            //Arrange
            var line = new CreateLineDto
            {
                ProviderId = ProviderEnum.Magfa,
                Number = "782132589",                   // ''                           // ''
                Credential = "{'Domain': '---', 'UserName'': '---' , ClientSecret' : '---'' }"
            };

            //Act
            var result = await PostAsyncWithoutDeserialize<CreateLineDto>("/Line/Create", line);
            string[] exceptionString = { "احراز هویت", "خطا در اطلاعات ورودی" };
            var x = exceptionString.Any(x => result.Contains(x));

            //Assert
            Assert.True(x);
        }


        [Fact]
        public async void MagfaProvider_InvalidNumberByLessThan4Char_ShouldFail()
        {
            //Arrange
            var line = new CreateLineDto
            {
                ProviderId = ProviderEnum.Magfa,
                Number = "87",
                Credential = "{'Domain': '---', 'UserName': '---' , 'ClientSecret' : '---' }"
            };

            //Act
            var result = await PostAsyncWithoutDeserialize<CreateLineDto>("/Line/Create", line);
            string[] exceptionString = { "احراز هویت", "خطا در اطلاعات ورودی" };
            var x = exceptionString.Any(x => result.Contains(x));

            //Assert
            Assert.True(x);
        }

        [Fact]
        public async void MagfaProvider_ValidNumberByEqual4Char_ShouldPass()
        {
            //Arrange
            var line = new CreateLineDto
            {
                ProviderId = ProviderEnum.Magfa,
                Number = "8765",
                Credential = "{'Domain': '---', 'UserName': '---' , 'ClientSecret' : '---' }"
            };

            //Act
            var result = await PostAsyncWithoutDeserialize<CreateLineDto>("/Line/Create", line);
            string[] exceptionString = { "احراز هویت", "خطا در اطلاعات ورودی" };
            var x = exceptionString.Any(x => result.Contains(x));

            //Assert
            Assert.False(x);
        }

        [Fact]
        public async void MagfaProvider_InvalidNumberByMoreThan15Char_ShouldFail()
        {
            //Arrange
            var line = new CreateLineDto
            {
                ProviderId = ProviderEnum.Magfa,
                Number = "1234567891234567",
                Credential = "{'Domain': '---', 'UserName': '---' , 'ClientSecret' : '---' }"
            };

            //Act
            var result = await PostAsyncWithoutDeserialize<CreateLineDto>("/Line/Create", line);
            string[] exceptionString = { "احراز هویت", "خطا در اطلاعات ورودی" };
            var x = exceptionString.Any(x => result.Contains(x));

            //Assert
            Assert.True(x);
        }


        [Fact]
        public async void MagfaProvider_ValidNumberByEqual15Char_ShouldPass()
        {
            //Arrange
            var line = new CreateLineDto
            {
                ProviderId = ProviderEnum.Magfa,
                Number = "12345678912345",
                Credential = "{'Domain': '---', 'UserName': '---' , 'ClientSecret' : '---' }"
            };

            //Act
            var result = await PostAsyncWithoutDeserialize<CreateLineDto>("/Line/Create", line);
            string[] exceptionString = { "احراز هویت", "خطا در اطلاعات ورودی" };
            var x = exceptionString.Any(x => result.Contains(x));

            //Assert
            Assert.False(x);
        }


        [Fact]
        public async void MagfaProvider_ValidNumberByEqual13Char_ShouldPass()
        {
            //Arrange
            var line = new CreateLineDto
            {
                ProviderId = ProviderEnum.Magfa,
                Number = "1234567891234",
                Credential = "{'Domain': '---', 'UserName': '---' , 'ClientSecret' : '---' }"
            };

            //Act
            var result = await PostAsyncWithoutDeserialize<CreateLineDto>("/Line/Create", line);
            string[] exceptionString = { "احراز هویت", "خطا در اطلاعات ورودی" };
            var x = exceptionString.Any(x => result.Contains(x));

            //Assert
            Assert.False(x);
        }


        [Fact]
        public async void MagfaProvider_InvalidCredentialByKaveNegarTemplateCredential_ShouldFail()
        {
            //Arrange
            var line = new CreateLineDto
            {
                ProviderId = ProviderEnum.Magfa,
                Number = "1234567891234",
                Credential = "{'apiKey': '---' }"
            };

            //Act
            var result = await PostAsyncWithoutDeserialize<CreateLineDto>("/Line/Create", line);
            string[] exceptionString = { "احراز هویت", "خطا در اطلاعات ورودی" };
            var x = exceptionString.Any(x => result.Contains(x));

            //Assert
            Assert.True(x);
        }

        ///Kave Negar

        [Fact]
        public async void KaveNegarProvider_ValidLine_ShouldPass()
        {
            //Arrange
            var line = new CreateLineDto
            {
                ProviderId = ProviderEnum.Kavenegar,
                Number = "2510023",
                Credential = "{'apiKey': '---' }"
            };

            //Act
            var result = await PostAsyncWithoutDeserialize<CreateLineDto>("/Line/Create", line);
            string[] exceptionString = { "احراز هویت", "خطا در اطلاعات ورودی" };
            var x = exceptionString.Any(x => result.Contains(x));

            //Assert
            Assert.False(x);
        }



        [Fact]
        public async void KaveNegarProvider_EmptyApiKey_ShouldFail()
        {
            //Arrange
            var line = new CreateLineDto
            {
                ProviderId = ProviderEnum.Kavenegar,
                Number = "2510023",
                Credential = "{'apiKey': '' }"
            };

            //Act
            var result = await PostAsyncWithoutDeserialize<CreateLineDto>("/Line/Create", line);
            string[] exceptionString = { "احراز هویت", "خطا در اطلاعات ورودی" };
            var x = exceptionString.Any(x => result.Contains(x));

            //Assert
            Assert.True(x);
        }


        [Fact]
        public async void KaveNegarProvider_NullCredential_ShouldFail()
        {
            //Arrange
            var line = new CreateLineDto
            {
                ProviderId = ProviderEnum.Kavenegar,
                Number = "2510023",
            };

            //Act
            var result = await PostAsyncWithoutDeserialize<CreateLineDto>("/Line/Create", line);
            string[] exceptionString = { "احراز هویت", "خطا در اطلاعات ورودی" };
            var x = exceptionString.Any(x => result.Contains(x));

            //Assert
            Assert.True(x);
        }



        [Fact]
        public async void KaveNegarProvider_EmptyCredential_ShouldFail()
        {
            //Arrange
            var line = new CreateLineDto
            {
                ProviderId = ProviderEnum.Kavenegar,
                Number = "2510023",
                Credential=""
            };

            //Act
            var result = await PostAsyncWithoutDeserialize<CreateLineDto>("/Line/Create", line);
            string[] exceptionString = { "احراز هویت", "خطا در اطلاعات ورودی" };
            var x = exceptionString.Any(x => result.Contains(x));

            //Assert
            Assert.True(x);
        }
        
        
        [Fact]
        public async void KaveNegarProvider_EmptyCredentialAndNullNumber_ShouldFail()
        {
            //Arrange
            var line = new CreateLineDto
            {
                ProviderId = ProviderEnum.Kavenegar,
                Credential=""
            };

            //Act
            var result = await PostAsyncWithoutDeserialize<CreateLineDto>("/Line/Create", line);
            string[] exceptionString = { "احراز هویت", "خطا در اطلاعات ورودی" };
            var x = exceptionString.Any(x => result.Contains(x));

            //Assert
            Assert.True(x);
        }
        


        [Fact]
        public async void KaveNegarProvider_NullCredentialAndEmptyNumber_ShouldFail()
        {
            //Arrange
            var line = new CreateLineDto
            {
                ProviderId = ProviderEnum.Kavenegar,
                Number="",
            };

            //Act
            var result = await PostAsyncWithoutDeserialize<CreateLineDto>("/Line/Create", line);
            string[] exceptionString = { "احراز هویت", "خطا در اطلاعات ورودی" };
            var x = exceptionString.Any(x => result.Contains(x));

            //Assert
            Assert.True(x);
        }


        [Fact]
        public async void KaveNegarProvider_EmptyNumber_ShouldFail()
        {
            //Arrange
            var line = new CreateLineDto
            {
                ProviderId = ProviderEnum.Kavenegar,
                Number="",
                Credential= "{'apiKey': 'sample' }"
            };

            //Act
            var result = await PostAsyncWithoutDeserialize<CreateLineDto>("/Line/Create", line);
            string[] exceptionString = { "احراز هویت", "خطا در اطلاعات ورودی" };
            var x = exceptionString.Any(x => result.Contains(x));

            //Assert
            Assert.True(x);
        }
        
        
        [Fact]
        public async void KaveNegarProvider_InvalidNumberByLessThan4_ShouldFail()
        {
            //Arrange
            var line = new CreateLineDto
            {
                ProviderId = ProviderEnum.Kavenegar,
                Number="120",
                Credential= "{'apiKey': 'sample' }"
            };

            //Act
            var result = await PostAsyncWithoutDeserialize<CreateLineDto>("/Line/Create", line);
            string[] exceptionString = { "احراز هویت", "خطا در اطلاعات ورودی" };
            var x = exceptionString.Any(x => result.Contains(x));

            //Assert
            Assert.True(x);
        }
        
        [Fact]
        public async void KaveNegarProvider_InvalidNumberByMoreThan15_ShouldFail()
        {
            //Arrange
            var line = new CreateLineDto
            {
                ProviderId = ProviderEnum.Kavenegar,
                Number="12352845362598152",
                Credential= "{'apiKey': 'sample' }"
            };

            //Act
            var result = await PostAsyncWithoutDeserialize<CreateLineDto>("/Line/Create", line);
            string[] exceptionString = { "احراز هویت", "خطا در اطلاعات ورودی" };
            var x = exceptionString.Any(x => result.Contains(x));

            //Assert
            Assert.True(x);
        }
        
        
        [Fact]
        public async void KaveNegarProvider_NullNumberAndCredential_ShouldFail()
        {
            //Arrange
            var line = new CreateLineDto
            {
                ProviderId = ProviderEnum.Kavenegar,
            };

            //Act
            var result = await PostAsyncWithoutDeserialize<CreateLineDto>("/Line/Create", line);
            string[] exceptionString = { "احراز هویت", "خطا در اطلاعات ورودی" };
            var x = exceptionString.Any(x => result.Contains(x));

            //Assert
            Assert.True(x);
        }
        
        
        [Fact]
        public async void KaveNegarProvider_NullAll_ShouldFail()
        {
            //Arrange
            var line = new CreateLineDto
            {
            };

            //Act
            var result = await PostAsyncWithoutDeserialize<CreateLineDto>("/Line/Create", line);
            string[] exceptionString = { "احراز هویت", "خطا در اطلاعات ورودی" };
            var x = exceptionString.Any(x => result.Contains(x));

            //Assert
            Assert.True(x);
        }
        
        
        [Fact]
        public async void KaveNegarProvider_InvalidCredentialByAddOneColon_ShouldFail()
        {
            //Arrange
            var line = new CreateLineDto
            {
                ProviderId= ProviderEnum.Kavenegar,
                Number="1201823",
                Credential = "{'apiKey' :: '---'}"
            };

            //Act
            var result = await PostAsyncWithoutDeserialize<CreateLineDto>("/Line/Create", line);
            string[] exceptionString = { "احراز هویت", "خطا در اطلاعات ورودی" };
            var x = exceptionString.Any(x => result.Contains(x));

            //Assert
            Assert.True(x);
        }
        


        [Fact]
        public async void KaveNegarProvider_InvalidCredentialByAddOneSingleQuotation_ShouldFail()
        {
            //Arrange
            var line = new CreateLineDto
            {
                ProviderId= ProviderEnum.Kavenegar,
                Number="1201823",
                Credential = "{'apiKey' : ''---'}"
            };

            //Act
            var result = await PostAsyncWithoutDeserialize<CreateLineDto>("/Line/Create", line);
            string[] exceptionString = { "احراز هویت", "خطا در اطلاعات ورودی" };
            var x = exceptionString.Any(x => result.Contains(x));

            //Assert
            Assert.True(x);
        }
        
        
        [Fact]
        public async void KaveNegarProvider_InvalidCredentialByLessOneSingleQuotation_ShouldFail()
        {
            //Arrange
            var line = new CreateLineDto
            {
                ProviderId= ProviderEnum.Kavenegar,
                Number="1201823",
                Credential = "{apiKey' : '---'}"
            };

            //Act
            var result = await PostAsyncWithoutDeserialize<CreateLineDto>("/Line/Create", line);
            string[] exceptionString = { "احراز هویت", "خطا در اطلاعات ورودی" };
            var x = exceptionString.Any(x => result.Contains(x));

            //Assert
            Assert.True(x);
        }
    }
}
