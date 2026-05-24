## Student Information
**Name:** Daryl James E. Padogdog
**Subject:** Software Design

## Laboratory Details
**Laboratory Session:** Week 7
**Tasks Status:** Complete

## Overview
This laboratory focuses on advanced event-driven and asynchronous programming features in a WinForms application with Entity Framework Core. The main topics include pagination for large datasets, error handling in async operations, and asynchronous file I/O for data export and import.

## Contents
- **Task 1:** Asynchronous Pagination — Fetch and navigate through books in pages of 10 using EF Core Skip/Take with async/await.
- **Task 2:** Error Handling in Async Operations — `SaveBookAsync` method with proper exception handling (`DbUpdateException`, general exceptions) and context cleanup.
- **Task 3:** Asynchronous File Export — Export all books to a pipe-delimited text file on the desktop using `StreamWriter.WriteLineAsync`.
- **Task 4 (Student Challenge):** Async Search by title with error handling + Async data Import from a `.txt` file using `File.ReadAllLinesAsync` and `SaveBookAsync`.

## Weekly Summary
A WinForms application was built with paginated book display using `ListBox`, page navigation buttons (`< Previous` / `Next >`), and a page counter label. The app includes a search feature that filters books by title asynchronously, an export function that writes book data to a text file, and an import function that reads a pipe-delimited file and inserts books into the database. All operations include progress bar feedback and status strip updates.

## Task Highlights
- **Task 1:** Implements pagination with `.Skip().Take()` — 30 seed books across 3 pages.
- **Task 2:** `SaveBookAsync` catches and wraps exceptions with meaningful messages.
- **Task 3:** Exports to `books_export.txt` on the desktop with ID|Title|ISBN|Price|Author format.
- **Task 4:** Search uses `Where(b => b.Title.Contains(query))`; Import parses pipe-delimited lines, auto-creates missing authors.
