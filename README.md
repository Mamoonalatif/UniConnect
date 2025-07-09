# 🌐 UniConnect

<div align="center">

**A modern, community-driven platform for university communication, event management, and student engagement**

*Stay Connected. Stay Informed. Stay Reunited.*

</div>

---

## 📖 Table of Contents

- [✨ Features](#-features)
- [🖼️ Screenshots](#️-screenshots)
- [🛠️ Tech Stack](#️-tech-stack)
- [📁 Project Structure](#-project-structure)
- [🚀 Setup & Installation](#-setup--installation)
- [📱 Usage](#-usage)
- [🤝 Contributing](#-contributing)
- [📄 License](#-license)

---

## ✨ Features

### 🔐 **User Authentication & Identity**
- Secure registration, login, and logout using **ASP.NET Core Identity**
- Comprehensive profile management with password reset capabilities
- Personal data download and management
- Role-based access control for authorized features

### 🎉 **Events Management**
- **Interactive event browsing** with category filtering
- **Voice-powered search** using browser speech recognition
- Detailed event pages with rich information (images, location, faculty, dates)
- **Real-time event carousel** on homepage
- Authenticated users can create and manage events
- Event search with intelligent filtering

### 🔍 **Lost & Found System**
- Report lost or found items with comprehensive details
- Advanced search and filtering capabilities
- Individual item detail pages with full information
- Type-based categorization (Lost/Found)
- Date and location tracking

### 🤖 **AI-Powered Chatbot (UniBot)**
- **Intelligent conversational AI** for instant assistance
- Real-time integration with events and lost & found data
- **Google Gemini API** integration for advanced queries
- Floating chat interface accessible from any page
- Natural language processing for user queries

### 💭 **Student Testimonials**
- Interactive testimonial submission system
- Scrollable testimonials showcase on homepage
- Story sharing with role-based categorization
- Community feedback and experiences

### 🎨 **Modern UI/UX Design**
- **Fully responsive** design with mobile-first approach
- Custom CSS animations and transitions
- Interactive modals and components
- Professional dark theme with accent colors
- Smooth carousel transitions and hover effects

### 🎤 **Voice Recognition**
- Browser-based speech recognition for event search
- Visual feedback during voice input
- Real-time speech-to-text conversion

### 📱 **Additional Features**
- About section with mission statement
- Social media integration
- Footer with quick navigation links
- Professional glass-morphism design elements

---

## 🖼️ Screenshots

<div align="center">

### 🏠 Homepage with Event Carousel
![Homepage](https://github.com/user-attachments/assets/f4550389-1234-4ed1-974c-1fbc45496626)

### 🎉 Events Management
![Events](https://github.com/user-attachments/assets/f6cb1fa1-7700-4fd2-939f-ac78ce830d94)

### 🔍 Lost & Found System
![Lost & Found](https://github.com/user-attachments/assets/157b8310-fb43-4dc7-98a3-0ab3666655f6)

### 🤖 AI Chatbot Interface
![Chatbot](https://github.com/user-attachments/assets/caaf157f-ac8a-4dd5-bfa1-2cb53591cbc4)

### 💭 Student Testimonials
![Testimonials](https://github.com/user-attachments/assets/4d71a2b9-9f92-43f1-a60c-a2be95209ab8)

### 🔐 Authentication System
![Auth](https://github.com/user-attachments/assets/528cbff3-e653-4e26-b311-1bc4d94ef4be)

</div>

---

## 🛠️ Tech Stack

<div align="center">

| Category | Technologies |
|----------|-------------|
| **Frontend** | ![Blazor](https://img.shields.io/badge/Blazor-Server-512BD4?logo=blazor) ![Bootstrap](https://img.shields.io/badge/Bootstrap-5-7952B3?logo=bootstrap) ![CSS3](https://img.shields.io/badge/CSS3-Custom-1572B6?logo=css3) ![JavaScript](https://img.shields.io/badge/JavaScript-ES6+-F7DF1E?logo=javascript) |
| **Backend** | ![.NET](https://img.shields.io/badge/.NET-8.0-512BD4?logo=dotnet) ![Entity Framework](https://img.shields.io/badge/Entity%20Framework-Core-512BD4) |
| **Database** | ![SQL Server](https://img.shields.io/badge/SQL%20Server-2022-CC2927?logo=microsoft-sql-server) |
| **Authentication** | ![Identity](https://img.shields.io/badge/ASP.NET-Identity-512BD4) |
| **AI Integration** | ![Google](https://img.shields.io/badge/Google-Gemini%20API-4285F4?logo=google) |
| **Icons** | ![FontAwesome](https://img.shields.io/badge/Font-Awesome-339AF0?logo=font-awesome) |

</div>

---

## 📁 Project Structure

```
UniConnect/
├── 📂 Components/
│   ├── 📂 Layout/           # MainLayout, NavMenu, responsive design
│   ├── 📂 Pages/            # Index, Events, EventDetails, LostFound, Chatbot
│   ├── 📂 Account/          # Identity system, Login, Register, Profile
│   └── 📂 Shared/           # Reusable UI components
├── 📂 Data/                 # AppDbContext, Entity Framework migrations
├── 📂 Modals/               # Data models (Event, LostFoundItem, Testimonial)
├── 📂 Services/             # Business logic services and ChatBot integration
├── 📂 wwwroot/              # Static assets (CSS, JS, images, Bootstrap)
│   ├── 📄 app.css          # Custom styling and animations
│   ├── 📄 chatbot.js       # AI chatbot functionality
│   ├── 📄 speech.js        # Voice recognition features
│   └── 📂 images/          # Project assets and media
├── 📄 Program.cs           # Application startup and configuration
├── 📄 appsettings.json     # Configuration settings
└── 📄 UniConnect.csproj    # Project dependencies and settings
```

---

## 🚀 Setup & Installation

### 📋 Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download) or later
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads) (LocalDB or full version)
- [Visual Studio 2022](https://visualstudio.microsoft.com/) or [VS Code](https://code.visualstudio.com/)
- Modern web browser with JavaScript enabled

### 🔧 Installation Steps

1. **Clone the repository**
   ```bash
   git clone https://github.com/your-username/UniConnect.git
   cd UniConnect
   ```

2. **Configure the database**
   ```json
   // Update appsettings.json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=UniConnectDb;Trusted_Connection=true;MultipleActiveResultSets=true"
     }
   }
   ```

3. **Install dependencies and apply migrations**
   ```bash
   dotnet restore
   dotnet ef database update
   ```

4. **Configure AI Chatbot (Optional)**
   ```javascript
   // Update chatbot.js with your Google Gemini API key
   const API_KEY = "your-gemini-api-key-here";
   ```

5. **Run the application**
   ```bash
   dotnet run --project UniConnect/UniConnect.csproj
   ```

6. **Access the application**
   ```
   🌐 Local: https://localhost:5001
   🌍 Network: Use the URL shown in your terminal
   ```

---

## 📱 Usage

### 🏠 **Getting Started**
1. **Register** for a new account or **login** with existing credentials
2. **Browse events** on the homepage carousel
3. **Search** for specific events using the search bar or voice recognition
4. **Explore** the lost & found section for items

### 🎉 **Event Management**
- **View Events**: Browse all upcoming events with filtering options
- **Add Events**: Authenticated users can create new events with images and details
- **Search Events**: Use text search or voice recognition to find specific events
- **Event Details**: Click on any event to view comprehensive information

### 🔍 **Lost & Found**
- **Report Items**: Submit lost or found items with detailed descriptions
- **Browse Items**: View all reported items with search and filter capabilities
- **Item Details**: Access detailed information about any reported item

### 🤖 **AI Chatbot**
- **Access**: Click the floating "💬UniBot" button on any page
- **Query Types**: Ask about events, lost & found items, or general questions
- **Natural Language**: Use conversational language for best results

### 💭 **Testimonials**
- **Share Stories**: Click "Share Your Story" to submit testimonials
- **Read Experiences**: Browse through community feedback and stories

---

## 🤝 Contributing

We welcome contributions from the community! Here's how you can help:

### 🛠️ **Development Setup**
1. Fork the repository
2. Create a feature branch (`git checkout -b feature/amazing-feature`)
3. Make your changes
4. Commit your changes (`git commit -m 'Add amazing feature'`)
5. Push to the branch (`git push origin feature/amazing-feature`)
6. Open a Pull Request

### 🐛 **Bug Reports**
- Use the issue tracker to report bugs
- Include detailed reproduction steps
- Provide environment information















