using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Linq;
using System.Threading.Tasks;
using SeleniumExtras.WaitHelpers;

[TestClass]
public class SidebarTests
{
    private IWebDriver _driver;
    private WebDriverWait wait;


    [TestInitialize]
    public void TestInitialize()
    {
        _driver = new ChromeDriver();
        wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(10));
        _driver.Navigate().GoToUrl("http://localhost:5104");
    }

    [TestCleanup]
    public void TestCleanup()
    {
        _driver.Quit();
    }

    [TestMethod]
    public void Sidebar_Loads_Correctly()
    {
        var sidebarElement =  wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("sidebar")));
        Assert.IsNotNull(sidebarElement);
    }
}

    //    var searchInput = driver.FindElement(By.ClassName("search-input"));
    //     searchInput.SendKeys("chest");
 
    //     var searchResultItem = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("search-result-item")));
    //     searchResultItem.Click();
 
    //     var workoutList = wait.Until(SeleniumExtras.WaitHelpers.ExpectedConditions.ElementIsVisible(By.ClassName("list-group")));
    //     var exercises = workoutList.FindElements(By.TagName("button"));
 
    //     Assert.IsTrue(exercises.Count > 0, "No exercises listed for the selected muscle group.");