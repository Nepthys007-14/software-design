## Student Information
**Name:** Daryl James E. Padogdog
**Subject:** Software Design

## Laboratory Details
**Laboratory Session:** Week 8
**Tasks Status:** Complete

## Overview
This laboratory focuses on integrating external REST APIs into a WinForms application using HttpClient with asynchronous operations. The Google Books API is used to fetch book data by ISBN and search by author, with full CRUD operations for a local database built on Week 6's implementation.

## Contents
- **Task 1:** Google Books API Integration — Fetch book details by ISBN using `HttpClient` and display in a multiline TextBox.
- **Task 2:** API Error Handling — `try/catch` blocks for `HttpRequestException`, `TaskCanceledException` (timeout), and validation errors with user-friendly messages.
- **Task 3a (Challenge):** Search Books by Author — Search the Google Books API by author name and display results in a ListBox.
- **Task 3b (Challenge):** API Pagination — Navigate through API search results with `<` / `>` buttons tracking `startIndex`.

## Weekly Summary
A full WinForms CRUD application (DataGridView, book/author management, search, progress bar) was extended with Google Books API integration. Users can look up books by ISBN to view title, authors, description, and metadata, and search for books by author with paginated results. All API calls are async with proper timeout and error handling.

## Task Highlights
- **Task 1:** `GetBookByIsbnAsync` sanitizes ISBN digits, queries `volumes?q=isbn:{isbn}`, deserializes JSON response into `GoogleVolumeInfo`.
- **Task 2:** Separate catch blocks for `ArgumentException`, `TaskCanceledException` (10s timeout), `HttpRequestException`, and general `Exception`.
- **Task 3a:** `SearchBooksByAuthorAsync` queries `volumes?q=inauthor:{author}` with `startIndex` and `maxResults` params.
- **Task 3b:** Pagination buttons update `_apiStartIndex` and re-query; label shows "Pg X/Y".
