# CS 230: Operating Platforms

This directory contains coursework and project artifacts from CS 230: Operating Platforms at Southern New Hampshire University. The course focused on how software design is influenced by the operating platforms and architectures that support an application, including operating systems, memory and storage management, distributed systems, networking, security, and cloud computing.

Throughout the course, I worked with **The Gaming Room**, a fictional client looking to expand its existing Android game, *Draw It or Lose It*, into a web-based application that could support users across multiple platforms.

## Portfolio Artifact

The primary portfolio artifact from this course is the completed software design document for The Gaming Room:

- [The Gaming Room Software Design Document](Module%2007/CS_230_10428_7-1_Blake_Merry.docx)

The document evaluates the client's requirements and recommends an architecture for moving *Draw It or Lose It* from a single Android platform to a distributed, web-based application.

## Reflection

### The Gaming Room and Its Requirements

The Gaming Room already had *Draw It or Lose It* running as an Android application and wanted to make the game available across additional platforms. The new application needed to support multiple games, teams, and players while ensuring that each name remained unique. It also needed to provide a common experience for users regardless of the operating system or device they were using. This meant considering not only the application code, but also the server platform, storage, memory, networking, security, and how clients would connect to the application.

### Developing the Software Design Document

One part of the project I think went particularly well was connecting the client's requirements to the recommendations instead of selecting technologies first and trying to justify them afterward. I compared Windows, Linux, macOS, and mobile platforms based on what the application actually needed and ultimately recommended a Linux-based server with browser-based clients. This provided a centralized environment for the application's game logic while avoiding the need to develop and maintain a separate native client for every operating system.

Working through the design document before completing the application code was also useful because it forced me to think about the relationships between the major parts of the system first. The domain model established how games, teams, and players related to one another, which translated naturally into the Java classes. The same was true for requirements such as maintaining a single game service and preventing duplicate entities. Having those decisions established beforehand made the implementation more deliberate instead of working them out one class at a time.

### What I Would Revise

If I were continuing to revise the design document, I would add more detail about how the recommended architecture would actually be deployed. The document explains why Linux, a distributed architecture, and browser-based clients are appropriate, but a deployment diagram could show more clearly how the web server, application services, database, and clients fit together. I would also include some initial resource estimates so that the recommendations for memory, storage, and scalability could be tied to a more concrete starting configuration.

### Designing Around the User

I interpreted the client's need for broader platform support as more than simply making the same application run on Windows, macOS, Linux, and mobile devices. Using a browser-based client allows those users to access the same application without requiring The Gaming Room to maintain several different native versions. Keeping the game state and business logic on a centralized server also provides a more consistent experience for everyone.

Considering those user needs is important because a technically functional application can still be a poor solution if it creates unnecessary limitations for the people using it. The architecture should support how users are expected to interact with the application rather than requiring them to work around the technology chosen to build it.

### My Approach to Software Design

My approach was to begin with the client's requirements and constraints, model the important parts of the application, and then evaluate the available technologies against those needs. From there, I could make recommendations for the operating platform, architecture, storage, memory management, networking, and security as parts of one overall system rather than as isolated decisions.

For a similar project in the future, I would use the same general process. I would also introduce a requirements matrix or comparison table earlier so that major architectural decisions could be traced directly back to specific requirements. For larger projects, I would add deployment diagrams and small prototypes earlier in the process as well. Those would make it easier to test assumptions about compatibility, performance, or networking before committing to the final architecture.
