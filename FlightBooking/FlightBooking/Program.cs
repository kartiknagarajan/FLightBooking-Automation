using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System.Threading;


namespace FlightBooking
{
    class Program
    {
        IWebDriver driver=new ChromeDriver();
       
        static void Main(string[] args)
        {
           
        }

        [SetUp]
        public void Initialize()
        {
            //Navigate to the MakeMyTripPage
            driver.Navigate().GoToUrl("http://makemytrip.com");
            
        }

        [Test]
        public void BookAReturnTrip()
        {
            //Getting the Element for the Flight Booking Tab and verifying if the element is displayed
            IWebElement pageFunction = driver.FindElement(By.XPath("//span[@class='flgh_pic tab_icn']"));
            var isFlightTabDisplayed = pageFunction.Displayed;

            //Click on the Flights tab to make sure that user is on the FLight Booking Page
            pageFunction.Click();
            Console.WriteLine("The User is on the FLight Bookings Page");

            
            Thread.Sleep(4500);/*Sleep time is provided for the Page to get loaded. Avg page load within 20 sec need to reduce the time here */

            //Element for Domestic Flight Booking tab and verifying if the element is displayed
            IWebElement domesticFlghtTabActive = driver.FindElement(By.XPath("//a[@tabindex='1' and @class='row segmented_btn first  active ']"));
            
            //Click on the Domestic tab to proceed with Domestic bookings only if the Domestic tab is inactive.
            if (!domesticFlghtTabActive.Displayed)
            {
                IWebElement inactiveDomesticFlightsbtn =
                    driver.FindElement(By.XPath("//a[@tabindex='1' and @class='row segmented_btn first ']"));
                inactiveDomesticFlightsbtn.Click();
                driver.Manage().Timeouts().ImplicitlyWait(TimeSpan.FromSeconds(60));
                Console.WriteLine("The user has clicked on the Domestic Flight Booking Tab");
            }
            
           /*Getting the Element for the Round Trip Radio Button and Verifying the visibility of the same on the page.*/

           //Verifying if the Round Trip Radio Button is already selected
            IWebElement isRoundTripRadioBtnActive =
                driver.FindElement(
                    By.XPath(
                        "//a[@id='round_trip_button1' and @class='round_trip_button trip_type row active seg_text']"));
            //If not Pre Selected Select the Round Trip Button.
            if (! isRoundTripRadioBtnActive.Displayed)
            {
                IWebElement roundTripRadioBtn = driver.FindElement(By.XPath("//div[@class='col-sm-2 col-xs-6' and @id='roundTripTab']"));
                roundTripRadioBtn.Click();
                Console.WriteLine("User Selected the Round Trip Option");
            }
            Console.WriteLine("The Round Trip Option was preselected");
            
            //This implicit wait is given for the page objects (advertisements) to load.
            Thread.Sleep(1000);

            /*Getting the current Sys date and saving it into different variables to be used in the Date Picker*/
            DateTime currentDatetime = System.DateTime.Today.Date;
            int currentDate = currentDatetime.Day;
            int currentMonth = currentDatetime.Month;
            int currentYr = currentDatetime.Year;


            /*Getting the return date which should be the following day to the departure date to be used in the Date Picker*/
            //Declaring the Return Date variables
            int returnDate = 0;
            int returnMonth =0;
            int returnYr = 0;

            //Determining the Return Dates which should be the next day of the current Date based on the Month and yr.
            switch (currentMonth)
            {
                case 1:
                    if (currentDate == 31)
                    {
                        returnDate = 1;
                        returnMonth = 2;
                        returnYr = currentYr;
                        

                    }
                    else
                    {
                        returnDate = currentDate + 1;
                        returnMonth = currentMonth;
                        returnYr = currentYr;
                    }
                    break;
                case 2:
                    if (currentYr%4 == 0)
                    {
                        //IN case of a Leap Yr Feb would have 29 days
                        if (currentDate == 29)
                        {
                            returnDate = 1;
                            returnMonth = 3;
                            returnYr = currentYr;

                        }
                        else
                        {
                            returnDate = currentDate + 1;
                            returnMonth = currentMonth;
                            returnYr = currentYr;
                        }
                    }
                    else
                    {
                        //Non Leap year makes Feb 28 day month.
                        if (currentDate == 28)
                        {
                            returnDate = 1;
                            returnMonth = 3;
                            returnYr = currentYr;

                        }
                        else
                        {
                            returnDate = currentDate + 1;
                            returnMonth = currentMonth;
                            returnYr = currentYr;
                        }
                    }
                    break;

                case 3:
                    if (currentDate == 31)
                    {
                        returnDate = 1;
                        returnMonth = 4;
                        returnYr = currentYr;

                    }
                    else
                    {
                        returnDate = currentDate + 1;
                        returnMonth = currentMonth;
                        returnYr = currentYr;
                    }
                    break;

                case 4:
                    if (currentDate == 30)
                    {
                        returnDate = 1;
                        returnMonth = 5;
                        returnYr = currentYr;

                    }
                    else
                    {
                        returnDate = currentDate + 1;
                        returnMonth = currentMonth;
                        returnYr = currentYr;
                    }
                    break;

                case 5:
                    if (currentDate == 31)
                    {
                        returnDate = 1;
                        returnMonth = 6;
                        returnYr = currentYr;

                    }
                    else
                    {
                        returnDate = currentDate + 1;
                        returnMonth = currentMonth;
                        returnYr = currentYr;
                    }
                    break;

                case 6:
                    if (currentDate == 30)
                    {
                        returnDate = 1;
                        returnMonth = 7;
                        returnYr = currentYr;

                    }
                    else
                    {
                        returnDate = currentDate + 1;
                        returnMonth = currentMonth;
                        returnYr = currentYr;
                    }
                    break;

                case 7:
                    if (currentDate == 31)
                    {
                        returnDate = 1;
                        returnMonth = 8;
                        returnYr = currentYr;

                    }
                    else
                    {
                        returnDate = currentDate + 1;
                        returnMonth = currentMonth;
                        returnYr = currentYr;
                    }
                    break;

                case 8:
                    if (currentDate == 31)
                    {
                        returnDate = 1;
                        returnMonth = 9;
                        returnYr = currentYr;

                    }
                    else
                    {
                        returnDate = currentDate + 1;
                        returnMonth = currentMonth;
                        returnYr = currentYr;
                    }
                    break;

                case 9:
                    if (currentDate == 30)
                    {
                        returnDate = 1;
                        returnMonth = 10;
                        returnYr = currentYr;

                    }
                    else
                    {
                        returnDate = currentDate + 1;
                        returnMonth = currentMonth;
                        returnYr = currentYr;
                    }
                    break;

                case 10:
                    if (currentDate == 31)
                    {
                        returnDate = 1;
                        returnMonth = 11;
                        returnYr = currentYr;

                    }
                    else
                    {
                        returnDate = currentDate + 1;
                        returnMonth = currentMonth;
                        returnYr = currentYr;
                    }
                    break;

                case 11:
                    if (currentDate == 30)
                    {
                        returnDate = 1;
                        returnMonth = 12;
                        returnYr = currentYr;

                    }
                    else
                    {
                        returnDate = currentDate + 1;
                        returnMonth = currentMonth;
                        returnYr = currentYr;
                    }
                    break;

                case 12:
                    if (currentDate == 31)
                    {
                        returnDate = 1;
                        returnMonth = 1;
                        returnYr = currentYr+1;

                    }
                    else
                    {
                        returnDate = currentDate + 1;
                        returnMonth = currentMonth;
                        returnYr = currentYr;
                    }
                    break;
            }

            //Finding the Element to enter the Departure Airport City
            IWebElement txtboxDepartureCity = driver.FindElement(By.XPath("//input[@id='from_typeahead1' and @placeholder='Type Departure City']"));

            if (txtboxDepartureCity.Displayed)
            {
                txtboxDepartureCity.Clear();
                txtboxDepartureCity.SendKeys("Bangalore, India (BLR)");
                //Clicking on the Webpage pane to make the selection stable
                IWebElement webPageEmptyArea = driver.FindElement(By.XPath("//span[@class='hidden-xs' and text()='Domestic & International']"));
                webPageEmptyArea.Click();
                Console.WriteLine("User Is Travelling from Bangalore, India");

            }

            //Finding the Element to enter the Arrival Airport City
            IWebElement txtboxArrivalCity =
                driver.FindElement((By.XPath("//input[@id='to_typeahead1' and @placeholder='Type Destination City']")));

            if (txtboxArrivalCity.Displayed)
            {
                txtboxArrivalCity.Clear();
                txtboxArrivalCity.SendKeys("New Delhi, India (DEL)");
                //Clicking on the Webpage pane to make the selection stable
                IWebElement webPageEmptyArea = driver.FindElement(By.XPath("//span[@class='hidden-xs' and text()='Domestic & International']"));
                webPageEmptyArea.Click();
                Console.WriteLine("User Is Travelling to New Delhi, India");
            }

            //Initializing the Data Months for Departure and Return as the make my trip internally takes January as 0th month.
            int depDataMonth = currentMonth - 1;
            int returnDataMonth = returnMonth - 1;

            //The Departure Date Setting.

            //Inititalizing the Departure Date picker Pop up.
            IWebElement dateboxDepartureDate = driver.FindElement(By.XPath("//a[@id='start_date_sec' and @tabindex='6']"));
            dateboxDepartureDate.Click();
            

            //Verifying that the datepicker that pops up is for the Departure Date
            IWebElement departureDatePickerHeading =
                driver.FindElement(By.XPath("//span[@class='pull-left' and text()='Select Departure Date']"));

            if (departureDatePickerHeading.Displayed)
            {
                IWebElement currentHighlightedDepDate = driver.FindElement(By.XPath("//td[@data-month='" + depDataMonth + "']//a[@href='#' and text()='" + currentDate + "']"));
                currentHighlightedDepDate.Click();
            }

            else
            {
                Console.Write("The Date Picker Clicked is not correct");
            }

            //Return Date Setting

            //Inititalizing the Return Date picker Pop up
            IWebElement dateboxRtrnDate = driver.FindElement(By.XPath("//a[@id='return_date_sec' and @tabindex='7']"));
            dateboxRtrnDate.Click();

            //Verifying the the datepicker that pops up is for the Return Date
            IWebElement rtrnDatePickerHeader = driver.FindElement(By.XPath("//span[@class='pull-left' and text()='Select Return Date']"));

            if (rtrnDatePickerHeader.Displayed)
            {
                IWebElement rtrnDate = driver.FindElement(By.XPath("//td[@data-month='" + returnDataMonth + "']//a[@href='#' and text()='" + returnDate + "']"));
                rtrnDate.Click();
            }

            /*Selecting the number of Passengers (Nothing mentioned assuming 1 Adult)*/

            //Verify that the Number of Adults =1
            IWebElement adultPassengerCnt =
                driver.FindElement(By.XPath("//span[@class='adultCount form-control' and text()='1']"));
            //If not 1 decrement count till it reaches 1
            while (! adultPassengerCnt.Displayed)
            {
                IWebElement adultcountDecrementer = driver.FindElement(By.XPath("//a[@tabindex='28']"));
                adultcountDecrementer.Click();
                adultPassengerCnt.FindElement(By.XPath("//span[@class='adultCount form-control' and text()='1']"));
            }
            
            //Verify that the number of Childeren  = 0
            IWebElement childPassengerCnt =
                driver.FindElement(By.XPath("//span[@class='form-control childCount' and text()='0']"));
            //If child cnt not 0 decrement till it is 0
            while (! childPassengerCnt.Displayed)
            {
                IWebElement childCntDecrementer = driver.FindElement(By.XPath("//div[@id='child_count']//a[@tabindex='30']"));
                childCntDecrementer.Click();
                childPassengerCnt.FindElement(By.XPath("//span[@class='form-control childCount' and text()='0']"));
            }

            //Verify that the Infant count is = 0
            IWebElement infantPassengercnt = driver.FindElement(By.XPath("//span[@class='infantCount form-control' and text()='0']"));
            //If Infant cnt is not 0 decrement till it is 0
            while (! infantPassengercnt.Displayed)//span[@class='infantCount form-control' and text()='0']
            {
                IWebElement infantCntDecrementer = driver.FindElement(By.XPath("//div[@id='infant_count']//a[@tabindex='32']"));
                infantCntDecrementer.Click();
                infantPassengercnt.FindElement(By.XPath("//span[@class='infantCount form-control' and text()='0']"));
            }

            /*Selecting Economy Class for the most cost effective trip*/
            //Click on the dropdown.
            IWebElement travelClassDropDown = driver.FindElement(By.XPath("//select[@id='class_selector']"));
            travelClassDropDown.Click();
            //Select Economy Class 
            IWebElement travelClass =
                driver.FindElement(
                    By.XPath("//select[@id='class_selector']//option[@value='E' and contains(text(),'Economy')]"));
            travelClass.Click();

            /*Finding the Flight Search and Clicking on it.*/
            IWebElement flightSearchBtn = driver.FindElement(By.Id("flights_submit"));
            flightSearchBtn.Click();

            /*Handle the pop up to search the Flights only*/
            string winIds = driver.WindowHandles.ToString();

           

            ////Switch to popup window
            driver.FindElement(By.ClassName("modal-content overlay_cases"));
            IWebElement closeWindowOverlay = driver.FindElement(By.XPath("//a[@class='close_overlay pull-right']"));
            closeWindowOverlay.Click();


            //driver.SwitchTo().ActiveElement().FindElement(By.XPath("//a[@class='close_overlay pull-right']")).Click();




        }

        [TearDown]
        public void CloseBrowser()
        {
            driver.Close();
        }
    
}
}
