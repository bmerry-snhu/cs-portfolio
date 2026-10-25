# CS 255: System Analysis and Design

This directory contains coursework and project artifacts from CS 255: System Analysis and Design at Southern New Hampshire University. The course focused on the systems development life cycle (SDLC), particularly the analysis and design phases, including requirements gathering, process and object modeling, UML diagrams, and technical documentation.

Throughout the course, I worked with **DriverPass**, a fictional driver training company seeking to develop a system that would help students prepare for their driving exams through online learning, practice tests, and on-the-road instruction.

## Portfolio Artifacts

The two primary portfolio artifacts from this course are:

- [DriverPass Business Requirements Document](Module%2005/CS_255_10105_5-2_BRD_Blake_Merry.docx)
- [DriverPass System Design Document](Module%2007/CS_255_10105_7-3_Blake_Merry.docx)

The business requirements document identifies the client's functional and nonfunctional requirements, system objectives, assumptions, and limitations. The system design document builds on those requirements using UML use case, activity, sequence, and class diagrams, along with the technical requirements necessary to support the proposed system.

Together, these documents demonstrate the process of translating a client's business needs into a technical design that developers could use during implementation.

## Reflection

### DriverPass and Its Requirements

DriverPass wanted a centralized system that could support its driver training services while reducing the amount of administrative work required from employees. Customers needed access to online classes, practice exams, and driving lesson scheduling, while employees needed tools to manage customer accounts, appointments, training packages, and business records. The system also needed to support different user permissions, maintain an activity history of reservation changes, and receive updated training information from the DMV.

The proposed solution was a cloud-hosted, web-based application accessible from computers and mobile devices. This would allow customers and employees to interact with the same centralized information while avoiding the need for DriverPass to maintain its own server infrastructure.

### Developing the System Design

One part of the project I think went particularly well was translating the client's requirements into specific system behaviors. Rather than treating appointment scheduling as a simple calendar function, I considered the different conditions that would need to be satisfied before a reservation could be completed. These included verifying that a customer had sufficient training hours, checking driver and vehicle availability, and preventing conflicting appointments.

The UML sequence diagram was especially useful for working through these interactions. It showed how the application, scheduling service, training package records, and reservation database would communicate, including alternative paths for situations where a customer was ineligible or an appointment became unavailable. Working through these scenarios helped me understand how much detail can exist behind a relatively straightforward user interaction.

### What I Would Revise

If I could revise one part of the documentation, I would expand the technical design for receiving updated information from the DMV. The client wanted training materials to stay current with DMV rules, policies, and practice questions, but the interview did not establish exactly how that information would be provided electronically.

I acknowledged this limitation in the requirements and design documents, but a more complete design would need to establish the available integration method, how updates would be validated, and what should happen if an update failed. Once the DMV's available interfaces were confirmed, I would document the update process in more detail and include the appropriate error handling and notification requirements.

### Designing Around the User

I approached the DriverPass requirements by considering how different people would actually use the system. Customers needed a straightforward way to access training materials and manage appointments, while the secretary needed to schedule lessons on behalf of customers who contacted the office. The owner needed reporting capabilities, and the IT administrator needed control over user accounts and permissions.

These differences influenced both the functional requirements and the UML models. For example, the scheduling process needed to account for customer eligibility and resource availability regardless of whether an appointment was requested online or entered by an employee. Similarly, role-based permissions were necessary to ensure users could access the information and functions appropriate to their responsibilities.

Considering user needs is important because a system can meet its technical requirements and still be difficult or impractical to use. The design needs to support the way people actually perform their work rather than forcing them to adapt to unnecessary technical limitations.

### My Approach to Software Design

My approach to software design is to start by understanding the problem the client is trying to solve before deciding how the system should be built. For DriverPass, that meant examining the interview, identifying functional and nonfunctional requirements, documenting assumptions, and then using UML diagrams to model the system's behavior and structure.

I found that process and object modeling complement each other. Activity and sequence diagrams help explain how the system behaves, while class diagrams describe the information and relationships that support those behaviors. Using these different perspectives provides a more complete understanding of the system than any single diagram could offer.

For future projects, I would continue using this requirements-first approach while introducing a requirements traceability matrix earlier in the design process. Connecting each requirement to its corresponding design elements and eventual test cases would make it easier to verify that nothing was overlooked. I would also place greater emphasis on reviewing exceptional scenarios and unresolved assumptions with stakeholders before moving into implementation.
