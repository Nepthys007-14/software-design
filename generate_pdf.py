from fpdf import FPDF

class PDF(FPDF):
    def header(self):
        self.set_font('Arial', 'B', 14)
        self.cell(0, 10, 'Technical Documentation: Task 4 - Week 3', 0, 1, 'L')
        self.set_font('Arial', '', 12)
        self.cell(0, 10, 'Project: Software Design', 0, 1, 'L')
        self.cell(0, 10, 'Module: LABORATORY EXERCISE 3 - Object-Oriented Design', 0, 1, 'L')
        self.cell(0, 10, 'Status: Answered', 0, 1, 'L')
        self.ln(5)

pdf = PDF()
pdf.add_page()
pdf.set_font('Arial', '', 12)

# Q1
pdf.set_font('Arial', 'B', 12)
pdf.multi_cell(0, 8, '1. How does polymorphism improve flexibility in object-oriented design?')
pdf.set_font('Arial', 'B', 12)
pdf.cell(0, 8, 'Answer:', 0, 1)
pdf.set_font('Arial', '', 12)
ans1 = "Polymorphism improves flexibility by allowing different classes to be treated as instances of the same base class through a common interface. This means a single function or method can operate on different types of objects, and each object will respond with its own specific behavior (e.g., overriding a method). It makes code more extensible, as new classes can be added without modifying existing code that uses the base class."
pdf.multi_cell(0, 8, ans1)
pdf.ln(5)

# Q2
pdf.set_font('Arial', 'B', 12)
pdf.multi_cell(0, 8, '2. What is the advantage of using inheritance to extend functionality?')
pdf.set_font('Arial', 'B', 12)
pdf.cell(0, 8, 'Answer:', 0, 1)
pdf.set_font('Arial', '', 12)
ans2 = "Inheritance allows a new class (subclass) to acquire the properties and methods of an existing class (base class). This promotes code reusability and reduces redundancy, as shared logic only needs to be written once in the base class. It also establishes a natural hierarchical relationship between classes, making the code easier to understand and maintain while allowing subclasses to add specific new features or override existing ones."
pdf.multi_cell(0, 8, ans2)
pdf.ln(5)

# Observation
pdf.set_font('Arial', 'B', 12)
pdf.cell(0, 8, 'Observation', 0, 1)
pdf.set_font('Arial', 'B', 12)
pdf.cell(0, 8, 'Answer:', 0, 1)
pdf.set_font('Arial', '', 12)
ans3 = "During this laboratory exercise, I observed how inheritance and polymorphism simplify code management. By creating a base Book class and derived classes like Ebook and Magazine, we avoided duplicating common properties like Title and Author. The polymorphic DisplayBooks function demonstrated how a single loop could handle an array of different book types, automatically calling the correct GetInfo method for each. This structure made it incredibly easy to add new types like Textbook and AudioBook without rewriting the core display logic, showcasing the power of OOP in building scalable systems."
pdf.multi_cell(0, 8, ans3)

pdf.output(r'c:\Desktop\software-design\Task-4_Week-3.pdf')
