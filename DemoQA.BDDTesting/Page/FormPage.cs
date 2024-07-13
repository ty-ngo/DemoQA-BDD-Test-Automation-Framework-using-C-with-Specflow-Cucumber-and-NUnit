using AventStack.ExtentReports.Utils;
using Core.Element;
using DemoQA.BDDTesting.Page;
using DemoQA.Services.Model.DataObject;
using FluentAssertions;
using OpenQA.Selenium;

namespace DemoQA.BDDTesting.Page
{
    public class FormPage : BasePage
    {
        public FormPage() { }

        public Element _txtFirstName = new Element(By.Id("firstName"));
        public Element _txtLastName = new Element(By.Id("lastName"));
        public Element _txtEmail = new Element(By.Id("userEmail"));
        public Element _lblGender(string gender) { return new Element(By.XPath($"//label[text()='{gender}']")); }
        public Element _txtMobile = new Element(By.Id("userNumber"));
        public Element _txtDateOfBirth = new Element(By.Id("dateOfBirthInput"));
        public Element _rdoYear = new Element(By.XPath("//select[contains(@class,'year-select')]"));
        public Element _rdoMonth = new Element(By.XPath("//select[contains(@class,'month-select')]"));
        public Element _btnDay(string targetDay) { return new Element(By.XPath($"//div[text()='{targetDay}' and not(contains(@class,'outside-month'))]")); }
        public Element _txtSubject = new Element(By.Id("subjectsInput"));
        public Element _inpPicture = new Element(By.Id("uploadPicture"));
        public Element _txaCurrentAddress = new Element(By.Id("currentAddress"));
        public Element _cboState = new Element(By.CssSelector("#state input"));
        public Element _cboCity = new Element(By.CssSelector("#city input"));
        public Element _btnSubmit = new Element(By.Id("submit"));
        public Element _lblThankYouMessage = new Element(By.XPath("//div[contains(@class,'modal-title')]"));

        public IList<Element> _lblHobbyOptions(List<string> hobbies)
        {
            List<Element> hobbiesElementsList = new List<Element>();
            foreach (string hobby in hobbies)
            {
                hobbiesElementsList.Add(new Element(By.XPath($"//label[text()='{hobby}']")));
            }
            return hobbiesElementsList;
        }

        public Element _lblResultInfo(string fieldName)
        {
            return new Element(By.XPath($"//td[text()='{fieldName}']/following-sibling::td"));
        }

        public void inputFirstName(string firstName)
        {
            if (!firstName.IsNullOrEmpty())
            {
                _txtFirstName.Enter(firstName);
            }
        }

        public void inputLastName(string lastName)
        {
            if (!lastName.IsNullOrEmpty())
            {
                _txtLastName.Enter(lastName);
            }
        }

        public void inputEmail(string email)
        {
            if (!email.IsNullOrEmpty())
            {
                _txtEmail.Enter(email);
            }
        }

        public void selectGender(string gender)
        {
            if (!gender.IsNullOrEmpty())
            {
                _lblGender(gender).ClickByJS();
            }
        }

        public void inputMobile(string mobile)
        {
            if (!mobile.IsNullOrEmpty())
            {
                _txtMobile.Enter(mobile);
            }
        }

        public void inputDateOfBirth(string dateOfBirth)
        {
            string[] split = dateOfBirth.Split([' ', '-']);
            _txtDateOfBirth.Click();
            _rdoYear.Select(split[2]);
            _rdoMonth.Select(split[1]);
            _btnDay(split[0]).Click();
        }

        public void inputSubject(List<string> subjects)
        {
            if (!subjects.IsNullOrEmpty())
            {
                foreach (string subject in subjects)
                {
                    _txtSubject.Enter(subject);
                    _txtSubject.Enter(Keys.Enter);
                }
            }
        }

        public void selectHobbies(List<string> hobbies)
        {
            if (!hobbies.IsNullOrEmpty())
            {
                foreach (Element _lblHobbyOption in _lblHobbyOptions(hobbies))
                {
                    _lblHobbyOption.ClickByJS();
                }
            }
        }

        public void uploadPicture(string path)
        {
            if (!path.IsNullOrEmpty())
            {
                _inpPicture.Enter(Directory.GetCurrentDirectory() + path);
            }
        }

        public void inputCurrentAddress(string address)
        {
            if (!address.IsNullOrEmpty())
            {
                _txaCurrentAddress.Enter(address);
            }
        }

        public void selectState(string state)
        {
            if (!state.IsNullOrEmpty())
            {
                _cboState.Enter(state);
                _cboState.Enter(Keys.Enter);
            }
        }

        public void selectCity(string city)
        {
            if (!city.IsNullOrEmpty())
            {
                _cboCity.Enter(city);
                _cboCity.Enter(Keys.Enter);
            }
        }

        public void clickSubmitButton()
        {
            _btnSubmit.Click();
        }

        public void fillAllStudentInfo(StudentDto student)
        {
            inputFirstName(student.FirstName);
            inputLastName(student.LastName);
            inputEmail(student.Email);
            selectGender(student.Gender);
            inputMobile(student.Mobile);
            inputDateOfBirth(student.DateOfBirth);
            inputSubject(student.Subjects);
            selectHobbies(student.Hobbies);
            uploadPicture(student.Picture);
            inputCurrentAddress(student.CurrentAddress);
            selectState(student.State);
            selectCity(student.City);
        }

        public void checkThankYouMessage()
        {
            _lblThankYouMessage.GetText().Should().Be("Thanks for submitting the form");
        }

        public void checkNameResult(string expectedFirstName, string expectedLastName)
        {
            _lblResultInfo("Student Name").GetText().Should().Be($"{expectedFirstName} {expectedLastName}");
        }

        public void checkEmailResult(string expectedValue)
        {
            _lblResultInfo("Student Email").GetText().Should().Be(expectedValue);
        }

        public void checkGenderResult(string expectedValue)
        {
            _lblResultInfo("Gender").GetText().Should().Be(expectedValue);
        }

        public void checkMobileResult(string expectedValue)
        {
            _lblResultInfo("Mobile").GetText().Should().Be(expectedValue);
        }

        public void checkDateOfBirthResult(string expectedValue)
        {
            string actualValue = _lblResultInfo("Date of Birth").GetText().Replace(',', ' ');
            actualValue.Should().Be(expectedValue);
        }

        public void checkSubjectsResult(List<string> expectedList)
        {
            string actual = _lblResultInfo("Subjects").GetText();

            if (expectedList.IsNullOrEmpty() && actual.IsNullOrEmpty())
            {
                return;
            }

            else if ((!expectedList.IsNullOrEmpty() && actual.IsNullOrEmpty()) ||
                     (expectedList.IsNullOrEmpty() && !actual.IsNullOrEmpty()))
            {
                true.Should().Be(false);
            }

            else
            {
                List<string> actualList = actual.Split(", ").ToList();

                if (actualList.Count != expectedList.Count)
                {
                    true.Should().Be(false);
                }

                actualList.Sort();
                expectedList.Sort();

                for (int i = 0; i < actualList.Count; i++)
                {
                    actualList[i].Should().Be(expectedList[i]);
                }
            }
        }

        public void checkHobbiesResult(List<string> expectedList)
        {
            string actual = _lblResultInfo("Hobbies").GetText();

            if (expectedList.IsNullOrEmpty() && actual.IsNullOrEmpty())
            {
                return;
            }

            else if ((!expectedList.IsNullOrEmpty() && actual.IsNullOrEmpty()) ||
                     (expectedList.IsNullOrEmpty() && !actual.IsNullOrEmpty()))
            {
                true.Should().Be(false);
            }

            else
            {
                List<string> actualList = actual.Split(", ").ToList();

                if (actualList.Count != expectedList.Count)
                {
                    true.Should().Be(false);
                }

                actualList.Sort();
                expectedList.Sort();

                for (int i = 0; i < actualList.Count; i++)
                {
                    actualList[i].Should().Be(expectedList[i]);
                }
            }
        }

        public void checkPictureResult(string expectedValue)
        {
            string[] pathSplit = expectedValue.Split("\\");
            string fileName = pathSplit[pathSplit.Length - 1];
            _lblResultInfo("Picture").GetText().Should().Be(fileName);
        }

        public void checkAddressResult(string expectedValue)
        {
            _lblResultInfo("Address").GetText().Should().Be(expectedValue);
        }

        public void checkStateCityResult(string expectedState, string expectedCity)
        {
            if (expectedState.IsNullOrEmpty())
            {
                _lblResultInfo("State and City").GetText().Should().Be("");
            }

            else if (expectedCity.IsNullOrEmpty())
            {
                _lblResultInfo("State and City").GetText().Should().Be(expectedState);
            }

            else
            {
                _lblResultInfo("State and City").GetText().Should().Be($"{expectedState} {expectedCity}");
            }
        }

        public void checkStudentInfo(StudentDto student)
        {
            checkNameResult(student.FirstName, student.LastName);
            checkEmailResult(student.Email);
            checkGenderResult(student.Gender);
            checkMobileResult(student.Mobile);
            checkDateOfBirthResult(student.DateOfBirth);
            checkSubjectsResult(student.Subjects);
            checkHobbiesResult(student.Hobbies);
            checkPictureResult(student.Picture);
            checkAddressResult(student.CurrentAddress);
            checkStateCityResult(student.State, student.City);
        }
    }
}
