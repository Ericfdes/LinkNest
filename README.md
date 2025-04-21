

# 🔗 URL Shortener & Click Tracker – Fullstack Dockerized App

A minimal yet production-ready **URL shortening application** with **click tracking**, built with:

- ⚙️ **.NET 8 (Backend)** – for secure and efficient URL hashing, metrics logging.
- ⚛️ **React + TypeScript (Frontend)** – sleek UI with animations using Framer Motion & DaisyUI.
- 🐳 **Dockerized with Docker Compose** – for seamless, isolated multi-container dev setup.
- 📊 **(Coming Soon)**: Prometheus + Grafana integration for metrics and monitoring.
- ☁️ **Deployment Target**: To be hosted on a Cloud Platform (e.g., AWS, Azure, or Railway).

---

## 📦 Features

- 🔗 Shorten long URLs into clean, trackable links.
- 📈 Track each link’s metadata (click count, last accessed time, IP history).
- 🧠 Schema-first backend design using Entity Framework Core and SQL Server.
- 🛠️ Containerized with Docker for backend, frontend, and database layers.
- 👁️ Monitoring: Click analytics dashboard with Grafana + Prometheus integration.
- 🚀 Cloud-ready and CI/CD-friendly architecture.

---

## 🚧 Technologies Used

| Layer        | Tech Stack                      |
| ------------ | ------------------------------- |
| Frontend     | React + TypeScript + DaisyUI    |
| Backend      | .NET 8 (ASP.NET Core)           |
| Database     | MS SQL Server                   |
| Containerization | Docker & Docker Compose    |
| Monitoring   | Prometheus + Grafana            |
| Deployment   | Cloud (AWS / Azure / Railway – In Progress) |

---

## 🐳 Local Setup (Dockerized)

```bash
# Clone the repo
git clone https://github.com/Ericfdes/LinkNest.git
cd LinkNest

# Run with Docker Compose
docker-compose up --build
```

- Frontend: https://localhost:5173  
- Backend API: https://localhost:3001

---

## 📈 Coming Up Next

- [ ] 🔍 **Prometheus metrics export** from backend.
- [ ] 📊 **Grafana Dashboards** to visualize click history & traffic patterns.
- [ ] ☁️ **Cloud Deployment** with Dockerized setup on AWS / Azure / Railway.
- [ ] 📁 Volume mounts for local persistence + real-time dev reload.
- [ ] 🛡️ Hardened Docker images & CI integration for auto-builds.

---

## 🧠 About the Developer

I'm passionate about building fullstack systems with a focus on **clean architecture**, **monitoring**, and **devops-readiness**.  
Currently diving deep into **Docker**, **System Design**, and **Cloud DevOps** to take my skills to the next level.

Let’s connect on [LinkedIn](https://www.linkedin.com/in/eric-fernandes-a1b7ba242/) or reach out via [ericfergoa@gmail.com](mailto:ericfergoa@gmail.com)!

---
