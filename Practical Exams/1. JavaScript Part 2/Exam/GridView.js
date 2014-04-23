(function () {
    if (!Storage.prototype.setObject) {
        Storage.prototype.setObject = function setObject(key, obj) {
            var jsonObj = JSON.stringify(obj);
            this.setItem(key, jsonObj);
        };

    }
    if (!Storage.prototype.getObject) {
        Storage.prototype.getObject = function getObject(key) {
            var jsonObj = this.getItem(key);
            var obj = JSON.parse(jsonObj);
            return obj;
        };
    }
})();

var controls = (function () {

    var rowIndex = 1;

    function SafeTags(str) {
        return str.replace(/&/g, '&amp;').replace(/</g, '&lt;').replace(/>/g, '&gt;');
    }

    var grids = [];

    var GridView = function (holder, isNested) {

        this.holder = holder;

        var gridViewHolder = document.querySelector(holder);

        var nested = isNested;
        var headerIndex = 0;

        if (gridViewHolder) {
            gridViewHolder.addEventListener("click", function (event) {

                if (!event) {
                    event = window.event;
                }

                event.stopPropagation();
                event.preventDefault();

                if (event.target instanceof HTMLTableCellElement && event.target.parentNode.nextElementSibling && event.target.parentNode.nextElementSibling.id === (event.target.parentNode.id + "nested")) {
                    var getedRow = document.querySelector("#" + event.target.parentNode.id);
                    var nextRow = getedRow.nextElementSibling;
                    if (nextRow.style.display === "none") {
                        nextRow.style.display = "";
                    }
                    else {
                        nextRow.style.display = "none";
                    }
                }

            }, false);

            gridViewHolder.addEventListener(("click"), function (event) {
                if (header.length > 0 && event.target.className == "header") {
                    var sortId = event.target.id[6];

                    var id = "#" + event.target.parentNode.parentNode.parentNode.parentNode.id;
                    
                    for (var i = 0; i < grids.length; i++) {
                        if (grids[i].holder == id) {

                            grids[i].rows.sort(function (a, b) {

                                var first = a.cells[parseInt(sortId)];
                                var second = b.cells[parseInt(sortId)];

                                if (first > second) {
                                    return 1;
                                }
                                if (first < second) {
                                    return -1;
                                }
                                if (first = second) {
                                    return 0;
                                }
                            });

                            var container = document.getElementById(event.target.parentNode.parentNode.parentNode.parentNode.id);

                            container.innerHTML = "";

                            grids[i].render();
                        }
                    }
                }
            }, false);
        }

        var rows = [];
        var header = [];

        this.rows = rows;

        this.addRow = function () {
            var rowItem = new GridViewRow(rowIndex);
            rowIndex++
            rowItem.add(arguments);
            rows.push(rowItem);
            return rowItem;
        }

        this.addHeader = function () {

            header = [];

            for (var i = 0; i < arguments.length; i++) {
                var currentCell = SafeTags(arguments[i].toString());
                header.push(currentCell);
            }
        }

        this.render = function () {
            var mainTable = document.createElement("table");
            mainTable.style.borderCollapse = "collapse";

            if (header) {
                var thead = document.createElement("thead");
                var row = document.createElement("tr");
                for (var i = 0; i < header.length; i++) {
                    var currentCellValue = SafeTags(header[i]);
                    var cell = document.createElement("th");
                    cell.style.border = "1px solid black";
                    cell.id = "header" + headerIndex;
                    headerIndex++;
                    cell.className = "header";
                    cell.style.padding = "5px 10px";
                    cell.style.backgroundColor = "#7FFF00";
                    cell.innerHTML = currentCellValue;
                    row.appendChild(cell);
                }
                thead.appendChild(row);
                mainTable.appendChild(thead);
            }

            var tdata = document.createElement("tbody");

            for (var j = 0; j < rows.length; j++) {
                var currentRow = rows[j].render();
                tdata.appendChild(currentRow);

                if (rows[j].nestedGrid) {
                    var nestedRow = document.createElement("tr");
                    var nestedTd = document.createElement("td");
                    nestedRow.style.display = "none";
                    nestedRow.id = currentRow.id + "nested";
                    nestedTd.style.border = "1px solid black";
                    nestedTd.colSpan = 4;
                    nestedTd.style.padding = "5px 10px";
                    nestedTd.appendChild(rows[j].nestedGrid.render());
                    nestedRow.appendChild(nestedTd);
                    tdata.appendChild(nestedRow);
                }
            }

            mainTable.appendChild(tdata);

            if (!nested) {
                gridViewHolder.appendChild(mainTable);
            }
            else {
                mainTable.style.margin = "auto";
                return mainTable;
            }
        }

        this.getGridViewData = function () {

            var schoolData = [];

            for (var i = 0; i < rows.length; i++) {
                var currentSchool = rows[i].cells;

                var schoolToAdd = new school(currentSchool[0], currentSchool[1], currentSchool[2], currentSchool[3]);

                if (rows[i].nestedGrid) {
                    var courses = rows[i].nestedGrid.rows;
                    var coursesToAddToSchool = [];

                    for (var j = 0; j < courses.length; j++) {
                        var currentCourse = courses[j].cells;
                        
                        var courseToAdd = new course(currentCourse[0], currentCourse[1], currentCourse[2]);

                        if (courses[j].nestedGrid) {
                            var students = courses[j].nestedGrid.rows;
                            var studentsToAddToCourse = [];

                            for (var k = 0; k < students.length; k++) {
                                var currentStudent = students[k].cells;

                                var studentToAdd = new student(currentStudent[0], currentStudent[1], currentStudent[2], currentStudent[3]);
                                studentsToAddToCourse.push(studentToAdd);
                            }

                            courseToAdd.students = studentsToAddToCourse;
                        }

                        coursesToAddToSchool.push(courseToAdd);
                    }
                    schoolToAdd.courses = coursesToAddToSchool;
                }

                schoolData.push(schoolToAdd);
            }

            return schoolData;
        }

    }

    var GridViewRow = function (index) {
        var cells = [];

        this.index = index;
        this.cells = cells;

        var nestedGrid;

        this.nestedGrid = nestedGrid;

        this.add = function (listOfCells) {
            for (var i = 0; i < listOfCells.length; i++) {
                var currentCell;

                if (listOfCells[i]) {
                    if (listOfCells[i] instanceof String) {
                        currentCell = SafeTags(listOfCells[i]);
                    }
                    else {
                        currentCell = listOfCells[i].toString();
                    }
                    cells.push(currentCell);
                }
            }
        }

        this.render = function () {
            var row = document.createElement("tr");
            row.id = "row" + this.index;
            for (var i = 0; i < cells.length; i++) {
                var currentCellValue = SafeTags(cells[i].toString());
                var cell = document.createElement("td");
                cell.style.border = "1px solid black";
                cell.style.padding = "5px 10px";
                cell.innerHTML = currentCellValue;
                row.appendChild(cell);
            }

            return row;
        }

        this.getNestedGridView = function () {
            this.nestedGrid = new GridView("#row" + this.index, true);
            return this.nestedGrid;
        }
    }

    function getGridView(holder) {
        var grid = new GridView(holder, false);
        grids.push(grid);
        return grid;
    }

    function buildGridView(holder, data) {
        var gridView = controls.getGridView(holder);

        gridView.addHeader("Name", "Location", "Courses", "Specialty");

        for (var i = 0; i < data.length; i++) {
            var currentSchool = data[i];

            gridView.addRow(currentSchool.name, currentSchool.location, currentSchool.numberOfCourses, currentSchool.specialty);

            if (currentSchool.courses) {

                var courses = gridView.rows[i].getNestedGridView();

                for (var j = 0; j < currentSchool.courses.length; j++) {
                    var currentCourse = currentSchool.courses[j];

                    courses.addHeader("Title", "Start date", "Total students");
                    courses.addRow(currentCourse.title, currentCourse.startDate, currentCourse.totalStudents);

                    if (currentCourse.students) {
                        var someStudents = gridView.rows[i].nestedGrid.rows[j].getNestedGridView();

                        for (var k = 0; k < currentCourse.students.length; k++) {
                            var currentStudent = currentCourse.students[i];

                            someStudents.addHeader("First name", "Last name", "Grade", "Mark");
                            someStudents.addRow(currentStudent.firstName, currentStudent.lastName, currentStudent.grade, currentStudent.mark);
                        }
                    }
                }
            }
        }

        return gridView;
    }

    return {
        getGridView: getGridView,
        buildGridView: buildGridView
    }

}());

function school(name, location, numberOfCourses, specialty, courses) {

    this.name = name;
    this.location = location;
    this.numberOfCourses = numberOfCourses;
    this.specialty = specialty;
    this.courses = courses;

}

function course(title, startDate, totalStudent, students) {

    this.title = title;
    this.startDate = startDate;
    this.totalStudents = totalStudent;
    this.students = students;

}

function student(firstName, lastName, grade, mark) {

    this.firstName = firstName;
    this.lastName = lastName;
    this.grade = grade;
    this.mark = mark;

}

var schoolRepository = (function () {

    return {
        save: function (key, data) {
            localStorage.setObject(key, data);
        },

        load: function (key) {
            var data = localStorage.getObject(key);
            return data;
        }
    }
}());

//test
var schoolsGrid = controls.getGridView("#grid-view-holder");

schoolsGrid.addHeader("Name", "Location", "Total students", "Specialty");
var PMG = schoolsGrid.addRow("PMG", "Burgas", 400, "Math");

var PMGNested = PMG.getNestedGridView();

PMGNested.addHeader("Ovchar", "Ovca", "Broi ovci");
var anotherNested = PMGNested.addRow("Pesho", "Megito", 400);

var anotherGrid = anotherNested.getNestedGridView();

anotherGrid.addHeader("na", "nana", "nanana", "nanananananan");
anotherGrid.addRow("bla", "bla", "blablabla", "blaaaaa");

PMGNested.addRow("Bai Ivan", "Mirelka", 500);

schoolsGrid.addRow("TUES", "Sofia", 500, "IT");
schoolsGrid.addRow("Telerik Academy", "Sofia", 5000, "IT");
var tags = schoolsGrid.addRow("<tag>", "</br>", "<ul>", "</div>");

var tagsGrid = tags.getNestedGridView();

tagsGrid.addHeader("Title", "Start Date", "Total student");
tagsGrid.addRow("JS 2", "11-april-2013", 400);
tagsGrid.addRow("SEO", "15-april-2013", 600);
tagsGrid.addRow("JS 3", "17-april-2013", 500);

schoolsGrid.render();

//test
var someStudent = new student("chocho", "chochov", 3, 5);
var anotherStudent = new student("chocho2", "chochov2", 2, 4);
var someCourse = new course("kpk", "12 april", [someStudent, anotherStudent]);
var anotherCourse = new course("js", "nekoga si", [someStudent]);
var firstSchool = new school("ta", "sf", 2, "it", [someCourse, someStudent]);
var secondSchool = new school("bla", "another bla", 4, "nikva", [someCourse]);
var schoolData = [firstSchool, secondSchool];

schoolRepository.save("school-repository", schoolData);

var data = schoolRepository.load("school-repository");

var schoolData = schoolsGrid.getGridViewData();
schoolRepository.save("school-from-grid", schoolData);

data = schoolRepository.load("school-from-grid")

var newGridBuildFromRepository = controls.buildGridView("#copied-grid-view", data);

newGridBuildFromRepository.render();

//console.log(data);
