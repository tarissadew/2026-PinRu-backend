# Changelog

All notable changes to this project will be documented in this file.
The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [1.0.0] - 2026-02-17

### Added
- **Backend Architecture:** Implemented core Entity, Data Transfer Object (DTO), and CRUD Controllers.
- **Database Migration:** Successfully migrated the primary database system to **PostgreSQL**.
- **Booking Management:** Added functionality to view booking history and update booking statuses.
- **User Management:** Implemented features to view and manage customer/user lists.
- **Frontend Integration:** Developed a responsive user interface using **React**, **Vite**, and **Tailwind CSS**.

### Improved
- **Authentication System:** Refined and strengthened authentication logic for both User and Admin roles.
- **Data Modeling:** Refactored the architecture by removing the standalone `Customer` model and consolidating it into the `User` model for better consistency.
- **UI/UX:** Enhanced layout responsiveness across desktop views.

### Fixed
- **Referential Integrity:** Resolved critical bugs where User and Room entities could not be deleted due to constraint conflicts.
- **Logic Errors:** Fixed issues in status transition logic for room bookings.

### Notes
- Ensure your `.env` file is updated with the new PostgreSQL connection string.
- Run `npm install` (or your preferred package manager command) to sync new dependencies.