
var disciplines = []
var teacherDisciplineSet = []
var rooms = []
var dedicatedRoomSet = []
var morningDiscipline = ''
var courses = []
var requirements = []

function addDiscipline() {
    let discipline = $('#discipline-input').val().trim();
    if (!discipline || disciplines.some(e => e === discipline)) {
        return;
    }
    disciplines.push(discipline);
    renderDisciplineList();
    $('#discipline-input').val(''); 
}

function deleteDiscipline(index) {
    disciplines.splice(index, 1);
    renderDisciplineList();
}

function renderDisciplineList() {
    const disciplineList = document.getElementById('discipline-list');
    disciplineList.innerHTML = '<h5>Materias agregadas:</h5>'; 

    disciplines.forEach((discipline, index) => {
        let html = `<div class="d-flex justify-content-between w-50">
                            <p>${discipline}</p>
                            <button onclick="deleteDiscipline(${index})" class="btn">
                                <i class="fa-solid fa-trash"></i>
                            </button>
                        </div>`;
        disciplineList.insertAdjacentHTML('beforeend', html);
    });

    let nextButton = document.getElementById('disciplines-next-button');

    if (disciplines.length != 0) {
        nextButton.removeAttribute('disabled');
    } else {
        nextButton.setAttribute('disabled', true);
    }
}

function renderDisciplineSelect() {
    const disciplineSelect = document.getElementById('discipline-select');
    disciplineSelect.innerHTML = '';

    disciplines.forEach((discipline, index) => {
        let option = document.createElement('option');
        option.value = index;
        option.textContent = discipline;
        disciplineSelect.appendChild(option);
    });
}

function addTeacher() {
    let discIndex = $('#discipline-select').val();
    let teacherName = $('#teacher-input').val().trim();

    teacherDisciplineSet.push({ teacherName, discipline: disciplines[discIndex] })
    renderTeacherList();
    $('#teacher-input').val('');
}

function deleteTeacher(index) {
    teacherDisciplineSet.splice(index, 1);
    renderTeacherList();
}

function renderTeacherList() {
    const teachersList = document.getElementById('teachers-list');
    teachersList.innerHTML = '<h5>Maestros agregados:</h5>';

    teacherDisciplineSet.forEach((obj, index) => {
        let html = `<div class="d-flex justify-content-between w-50">
                            <p>"${obj.teacherName}" enseña "${obj.discipline}"</p>
                            <button onclick="deleteTeacher(${index})" class="btn">
                                <i class="fa-solid fa-trash"></i>
                            </button>
                        </div>`;
        teachersList.insertAdjacentHTML('beforeend', html);
    });

    let nextButton = document.getElementById('teacher-next-button');

    if (teacherDisciplineSet.length != 0) {
        nextButton.removeAttribute('disabled');
    } else {
        nextButton.setAttribute('disabled', true);
    }
}

function addRoom() {
    let room = $('#room-input').val().trim();
    if (!room || rooms.some(e => e === room)) {
        return;
    }
    rooms.push(room);
    renderRoomList();
    $('#room-input').val('');
}

function deleteRoom(index) {
    rooms.splice(index, 1);
    renderRoomList();
}

function renderRoomList() {
    const roomList = document.getElementById('room-list');
    roomList.innerHTML = '<h5>Aulas agregadas:</h5>';

    rooms.forEach((room, index) => {
        let html = `<div class="d-flex justify-content-between w-50">
                            <p>${room}</p>
                            <button onclick="deleteRoom(${index})" class="btn">
                                <i class="fa-solid fa-trash"></i>
                            </button>
                        </div>`;
        roomList.insertAdjacentHTML('beforeend', html);
    });

    let nextButton = document.getElementById('room-next-button');

    if (rooms.length != 0) {
        nextButton.removeAttribute('disabled');
    } else {
        nextButton.setAttribute('disabled', true);
    }
}

function renderDedicatedRoomSelects() {
    const roomSelect = document.getElementById('room-select');
    const roomDiscSelect = document.getElementById('room-discipline-select');
    roomSelect.innerHTML = '';
    roomDiscSelect.innerHTML = '';

    rooms.forEach((room, index) => {
        let option = document.createElement('option');
        option.value = index;
        option.textContent = room;
        roomSelect.appendChild(option);
    });

    disciplines.forEach((discipline, index) => {
        let option = document.createElement('option');
        option.value = index;
        option.textContent = discipline;
        roomDiscSelect.appendChild(option)
    });
}

function addDedicatedRoom() {
    let roomIndex = $('#room-select').val()
    let disciplineIndex = $('#room-discipline-select').val()

    dedicatedRoomSet.push({ room: rooms[roomIndex], discipline: disciplines[disciplineIndex] })
    renderDedicatedRoomList();
}

function deleteDedicatedRoom(index) {
    dedicatedRoomSet.splice(index, 1);
    renderDedicatedRoomList();
}

function renderDedicatedRoomList() {
    const dedicatedList = document.getElementById('dedicated-list');
    dedicatedList.innerHTML = '<h5>Aulas dedicadas:</h5>';

    dedicatedRoomSet.forEach((obj, index) => {
        let html = `<div class="d-flex justify-content-between w-50">
                            <p>"${obj.discipline}" se enseña en "${obj.room}"</p>
                            <button onclick="deleteDedicatedRoom(${index})" class="btn">
                                <i class="fa-solid fa-trash"></i>
                            </button>
                        </div>`;
        dedicatedList.insertAdjacentHTML('beforeend', html);
    });

    let nextButton = document.getElementById('dedicated-next-button');

    if (dedicatedRoomSet.length != 0) {
        nextButton.removeAttribute('disabled');
    } else {
        nextButton.setAttribute('disabled', true);
    }
}

function renderMorningSelect() {
    const disciplineSelect = document.getElementById('morning-select');
    disciplineSelect.innerHTML = '';

    disciplines.forEach((discipline, index) => {
        let option = document.createElement('option');
        option.value = discipline;
        option.textContent = discipline;
        disciplineSelect.appendChild(option);
    });
}


function morningNextButton() {
    morningDiscipline = $('#morning-select').val()
}

function addCourse() {
    let course = $('#course-input').val().trim();
    if (!course || courses.some(e => e === course)) {
        return;
    }
    courses.push(course);
    renderCourseList();
    $('#course-input').val('');
}

function deleteCourse(index) {
    courses.splice(index, 1);
    renderCourseList();
}

function renderCourseList() {
    const courseList = document.getElementById('course-list');
    courseList.innerHTML = '<h5>Cursos agregados:</h5>';

    courses.forEach((course, index) => {
        let html = `<div class="d-flex justify-content-between w-50">
                            <p>${course}</p>
                            <button onclick="deleteDiscipline(${index})" class="btn">
                                <i class="fa-solid fa-trash"></i>
                            </button>
                        </div>`;
        courseList.insertAdjacentHTML('beforeend', html);
    });

    let nextButton = document.getElementById('course-next-button');

    if (disciplines.length != 0) {
        nextButton.removeAttribute('disabled');
    } else {
        nextButton.setAttribute('disabled', true);
    }
}

function renderRequirementSelect() {
    const courseSelect = document.getElementById('requirement-course-select');
    const disciplineSelect = document.getElementById('requirement-discipline-select');
    courseSelect.innerHTML = '';
    disciplineSelect.innerHTML = '';

    courses.forEach((course, index) => {
        let option = document.createElement('option');
        option.value = index;
        option.textContent = course;
        courseSelect.appendChild(option);
    });
    
    disciplines.forEach((discipline, index) => {
        let option = document.createElement('option');
        option.value = index;
        option.textContent = discipline;
        disciplineSelect.appendChild(option);
    });
}

function addRequirement() {
    let courseIndex = $('#requirement-course-select').val()
    let disciplineIndex = $('#requirement-discipline-select').val()
    let dailyHours = $('#daily-hours-input').val()
    let weeklyDays = $('#weekly-days-input').val()

    requirements.push({ course: courses[courseIndex], discipline: disciplines[disciplineIndex], dailyHours, weeklyDays })

    renderRequirementsList()
}

function deleteRequirement(index) {
    requirements.splice(index, 1);
    renderRequirementsList();
}

function renderRequirementsList() {
    const requirementList = document.getElementById('requirement-list');
    requirementList.innerHTML = '<h5>Requerimientos agregados:</h5>';

    requirements.forEach((requirement, index) => {
        let html = `<div class="d-flex justify-content-between w-50">
                            <p>${requirement.course} - ${requirement.discipline} - ${requirement.dailyHours} - ${requirement.weeklyDays}</p>
                            <button onclick="deleteRequirement(${index})" class="btn">
                                <i class="fa-solid fa-trash"></i>
                            </button>
                        </div>`;
        requirementList.insertAdjacentHTML('beforeend', html);
    });

    let finishButton = document.getElementById('requirement-finish-button');

    if (requirements.length != 0) {
        finishButton.removeAttribute('disabled');
    } else {
        finishButton.setAttribute('disabled', true);
    }
}


function handleFinish() {
    $('#error-display').css('display', 'none')
    let dataToRun = { teacherDisciplineSet, rooms, dedicatedRoomSet, morningDiscipline, requirements, runExample: false }
    $('#spinner').css('display', 'inline-block')
    $('#timer').css('display', 'inline-block')
    startTimer()


    $.ajax({
        type: "POST",
        url: "/Tabling/Run",
        data: dataToRun,
        success: function (data) {
            handleSuccess(data)
        },
        error: function (error) {
            console.log(error)
        }
    })
}


function runExample() {
    $('#error-display').css('display', 'none')
    $('#example-button').css('display', 'none')
    $('#spinner').css('display', 'inline-block')
    $('#timer').css('display', 'inline-block')
    startTimer()


    $.ajax({
        type: "POST",
        url: "/Tabling/Run",
        data: {runExample: true},
        success: function (data) {
            handleSuccess(data)
        },
        error: function (error) {
            console.log(error)
        }
    })
}

function handleSuccess(data) {
    if (data.solveState.solve_status == 'infeasible_solution') {
        data.errorMessage = 'Solución inviable'
    }
    if (data.errorMessage) {
        $('#spinner').css('display', 'none')
        $('#timer').css('display', 'none')
        $('#example-button').css('display', 'inline-block')
        $('#error-display').css('display', 'block')
        $('#error-display').html(data.errorMessage)
        return;
    }


    var object = JSON.parse(atob(data.outputData[0].content))
    var sortedData = arrangeData(object)

    $.ajax({
        type: "POST",
        url: "/Tabling/GetPartialView",
        data: sortedData,
        success: function (data) {
            $('#card-content').html(data)
        },
        error: function (error) {
            console.log(error)
        }
    })
}


