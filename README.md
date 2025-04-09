This is the first somewhat larger project I’ve done. I used **C#** to build a **CAD like graphical drawing application**. The project served as a hands-on learning experience, providing me with a deeper understanding of concepts like **Object-Oriented Programming (OOP)**, **event-driven programming**, and graphical interface design using the **WinForms** framework. While the app works as intended, I recognize areas where the code could be better organized and plan to rebuild it from scratch in the future.

---

## Features

### 1. Drawing Capabilities
- Draw the following shapes using mouse input:
  - **Node**: Specify a point.
  - **Line**: Specify two endpoints.
  - **Rectangle**: Specify two diagonal corners.
  - **Circle**: Specify the center and a point on the circumference.
  - **Rhombus**: Specify the center and a corner point.

- Each shape can be customized:
  - **Color**: Choose any color for the shape.
  - **Line thickness**: Adjustable from 1 to 5 pixels.
  - **Point size**: Adjustable for node elements.

- Multiple shapes (including mixed types) can coexist in a single workspace.


### 2. Object Interaction
- Mouse cursor changes to indicate when it's near a drawn object.
- Tooltips appear over shapes displaying their type (e.g., "Circle", "Line").


### 3. Workspace Management
- Fully **zoomable** and **pannable** canvas.
- Shapes remain visible and properly scaled during interactions.
- Coordinate system conversion:
  - **Screen coordinates** ↔ **World coordinates**, ensuring transformations remain accurate.


### 4. Save and Load
- Save your workspace, including all drawn shapes and user customization, in a `.json` file format.
- Reload saved files seamlessly to continue work exactly as you left it.


### 5. User Data Integration
- A **form** is included to collect user information:
  - Name
  - Email
  - Date of Birth
  - Address
  - Postal Code
- **Validation** ensures proper input formats.
- User data is saved with the drawing file and reloaded automatically.

---

## Technologies Used
- **C#**
- **WinForms**: For creating the graphical user interface.
- **JSON.NET (Newtonsoft.Json)**: For saving and loading data in JSON format.
- **Object-Oriented Design Patterns**:
  - Command Pattern (e.g., for shape drawing actions).
  - MVC/MVP-like separation of concerns.
- **GDI+**: For rendering shapes and handling graphics.

---

## How to Run

1. Clone this repository.
   ```bash
   git clone https://github.com/yourusername/drawing-app.git
   cd drawing-app
   ```
2. Open the project in Visual Studio.
3. Build and run the solution.
4. Explore the app's features:
   - Start a **new drawing** or **load an existing file** from the welcome screen.
   - Use the toolbar to draw shapes, customize settings, and manage your workspace.

---

## Known Issues
1. **Code Organization**:
    - Some classes are overloaded with logic, breaking the **single responsibility principle** (e.g., handling UI, business logic, and event handling in one place).
    - Coupling between components could be reduced to improve testability and scalability.
2. **Object-Oriented Design**:
    - While I applied OOP principles, I feel some abstractions (e.g., drawing states and shapes) could be refactored for better clarity and maintainability.
    - Adding design patterns such as the **factory pattern** for shape creation could simplify extensions.
3. **Error Handling**:
    - Error handling for file operations (e.g., loading corrupted files) needs better fallback mechanisms to prevent application crashes.
4. **Performance**:
    - The rendering and transformation logic for zoom and pan, though functional, may need optimization for handling larger datasets or more complex drawings.

---

## Lessons Learned
This project was an invaluable learning experience. Here are some of the key takeaways:
1. **Event-Driven Programming**: Handling mouse events (click, move, drag) and tying them to logical actions.
2. **Separation of Concerns**: Using MVP patterns to decouple UI logic from application logic.
3. **State Management**: Implementing drawing states (e.g., drawing a line or rectangle) to control dynamic behavior.
4. **JSON Serialization**: Understanding how to store and retrieve complex object states efficiently.
5. **User Experience Design**: Thinking about usability when creating features like zooming, panning, and persistent data storage.

---

## Future Improvements
I plan to rewrite this project from scratch, implementing better practices and improving the user experience. Key goals:
1. Refactor the code for **cleaner architecture** with further abstraction and modularity.
2. Introduce **unit testing** for core functionalities.
3. Enhance file management with better error handling and more intuitive dialogs.
4. Support additional shape types and features like snapping, gridlines, and undo/redo functionality.
