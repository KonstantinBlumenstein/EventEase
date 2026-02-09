# EventEase

A Blazor Server application for browsing, discovering, and registering for events. Built with .NET 10.0 and interactive server-side rendering.

## Features

- **Event Browsing**: View a grid of upcoming events with images, dates, locations, and capacity information
- **Event Details**: Detailed event pages with full descriptions and registration options
- **Registration Form**: Complete registration with form validation (name, email, phone)
- **User Session Management**: Track user registrations within the session
- **Attendance Tracker**: View registered attendees and capacity statistics for each event

## Getting Started

### Prerequisites

- .NET 10.0 SDK or later

### Running the Application

```bash
# Navigate to the project directory
cd EventEase

# Restore dependencies
dotnet restore

# Run the application
dotnet run
```

The application will be available at:
- HTTP: http://localhost:5156
- HTTPS: https://localhost:7109

## Project Structure

```
EventEase/
├── Components/
│   ├── Pages/
│   │   ├── Home.razor              # Event listing page
│   │   ├── EventDetails.razor      # Event details & registration
│   │   └── AttendanceTracker.razor # Attendance tracking page
│   └── Layout/
│       ├── MainLayout.razor        # Main layout wrapper
│       └── NavMenu.razor           # Navigation component
├── Models/
│   ├── Event.cs                    # Event data model
│   └── Registration.cs             # Registration model with validation
├── Services/
│   ├── EventService.cs             # Event data and registration logic
│   └── UserSessionService.cs       # User session state management
├── wwwroot/
│   └── app.css                     # Application styles
└── Program.cs                      # Application entry point
```

## Key Implementation Details

### Two-Way Data Binding

The registration form uses Blazor's `@bind-Value` directive for two-way data binding:

```razor
<InputText id="name" @bind-Value="registrationModel.Name" />
<InputText id="email" @bind-Value="registrationModel.Email" />
```

### Form Validation

Validation is implemented using DataAnnotations on the Registration model:

```csharp
[Required(ErrorMessage = "Name is required")]
[StringLength(100, MinimumLength = 2)]
public string Name { get; set; }

[Required(ErrorMessage = "Email is required")]
[EmailAddress(ErrorMessage = "Please enter a valid email address")]
public string Email { get; set; }
```

### State Management

User session state is managed through a scoped `UserSessionService` that tracks registrations per Blazor circuit (user session).

---

## Copilot Assistance Summary

This project was developed with AI assistance (GitHub Copilot / Claude Code) throughout the development process:

### 1. Initial Project Scaffolding
- Copilot assisted in setting up the Blazor Server project structure
- Generated the initial Program.cs configuration with proper service registration
- Created the App.razor and Routes.razor components following Blazor conventions

### 2. Event Card Component Generation
- Copilot helped design and generate the Event Card component layout
- Suggested the grid layout using CSS Grid with responsive `auto-fill` and `minmax`
- Generated hover effects and transition animations for better UX
- Assisted with image handling and placeholder content

### 3. Routing Setup and Debugging
- Copilot configured the `@page` directives for all components
- Implemented route parameters (e.g., `/event/{EventId:int}`)
- Set up the NavigationManager for programmatic navigation
- Configured 404 handling with the NotFound component

### 4. Form Validation Implementation
- Generated the Registration model with DataAnnotations attributes
- Created the EditForm component structure with proper validation
- Implemented `DataAnnotationsValidator` and `ValidationMessage` components
- Styled validation states (valid/invalid) with CSS

### 5. State Management Patterns
- Designed the UserSessionService for tracking user registrations
- Implemented scoped service registration for per-circuit state in Blazor Server
- Created thread-safe operations in EventService using lock statements
- Managed component state with proper lifecycle methods (OnInitializedAsync)

### 6. Performance Optimization
- Copilot suggested input validation patterns to prevent invalid submissions
- Implemented capacity checking before registration
- Added duplicate email detection to prevent double registrations
- Used async/await patterns throughout for non-blocking operations

### 7. Attendance Tracker Feature
- Generated the AttendanceTracker component with statistics display
- Created the capacity progress bar visualization
- Implemented email masking for privacy (e.g., `j***n@email.com`)
- Designed the responsive attendee table layout

### 8. CSS and Styling
- Copilot generated comprehensive CSS for all components
- Created a consistent color scheme and design system
- Implemented responsive design with media queries
- Added interactive states (hover, focus, active) for better UX

---

## Technologies Used

- **Framework**: ASP.NET Core 10.0
- **UI**: Blazor Server (Interactive Server Components)
- **Styling**: Custom CSS with Bootstrap integration
- **State**: Scoped services for session management
- **Validation**: DataAnnotations with EditForm

## License

This project is for educational purposes.
