# C# Learning activity 1
This activity will help you gain more experience with C# and some essential features and libraries. As part of this activity you will gain more knowledge of how C# programs are designed, structured and tested to prepare you to develop more tools and programs in the very near future. 

## Activity Description
To help you learn about these libraries and C# features, you task is to to the following:
- [ ] Make an authenticated GET request to canvas, getting the api endpoint from a command line parameter 
- [ ] Using JSON.NET and CSV helper, create a CSV of the course.
- [ ] Save the CSV to the hard drive.

As you design and work on this assignment, try to apply the Object Oriented Design Principles that you just learned. The more scaleable your program, the happier you will be later. :D 

## Featured Libraries
These libraries are the core libraries for this project. Understand that these are the libraries that will be used in the future to make our Audit Program. 

### Canvas API
The [Canvas API](https://canvas.instructure.com/doc/api/) documentation is a great resource on how to use the API and get a course from the Canvas servers. Make sure that you are using HTTPS and that you put the Auth Token in the correct place. Do not hard code the auth token, use a environment variable.

### JSON.NET
The [JSON.NET](https://www.newtonsoft.com/json) is a .NET framework for handling JSON. This is the fastest in terms of handling JSON. If this library had a catch phrase, it would be "Speed, I am Speed!"

### CSV Helper
The [CSV Helper](https://joshclose.github.io/CsvHelper/) library is .NET library for reading and writing CSV files. Extremely fast, flexible, and easy to use.

### C# HttpClient Class
The [HttpClient Class](https://docs.microsoft.com/en-us/dotnet/api/system.net.http.httpclient?view=netframework-4.8) provides a base class for sending HTTP requests and receiving HTTP responses from a resource identified by a URI.