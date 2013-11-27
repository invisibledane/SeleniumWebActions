SeleniumWebActions
==================
Rev. date: 11/27/2013
Author: Dane
Contact: dgrace@mykolab.com

This is a library of web actions Selenium engineers will find themselves utilizing often. 

C# NOTES: I leverage the Visual Studio unit test tools to Assert Inconclusive in the case of an exception. I've found this to be a very efficient way to handle asserts in general. E-mail me and I'd be more than happy to create a framework agnostic version.

========== Current list of methods ==========

1. WaitForElement: Waits for a number of seconds (passed into the method) until an element is found by ID.

2. DriverQuit: Closes and disposes of the driver passed into the method.

3. GetElementByID: Find and instantiates an element by ID. Works great in conjunction with WaitForElement.

4. GetElementByLinkText: Find and instantiates an element by LinkText. Great for finding elements without IDs - before, of course, you berrate the developer into providing one.

5. Pause: Pauses everything. Make the test wait while things load or until you can catch your breath.

6. ClickItem: Pass in a webelement, then click it with the mouse

7. GetText: Extract the text from a WebElement. Mostly used for textboxes.

8. HoverCursoerOverWebElement: Hovers cursor over a web element, good for selecting items from dropdown lists.

9. SelectDDLEntryByArrowKey: Click on the DDL, then press the down number for a specified number of times (passed into the method as an in).

10. SleectFromDDLByText: Clicks on DDL then sends text to the it. Sends enter key to select.

11. SendKeyEnter: Sends the enter key to an element.

12. SendKeyDownArrow: Sends down arrow to an element.

13. SendKeySpaceBar: Sends spacebar to an element.

14. SendKeyTab: Sends the tab key to an element.

15. SendKeyUpArrow: Sends Up arrow key to an element.

16. SendText: Sends text to an element - great for textboxes.

17. GoToUrl: Navigates browser to a specific URL.

