
let startTime;
let updatedTime;
let timerInterval;
let running = false;

const startButton = document.getElementById('start-button');
const minutesElement = document.getElementById('minutes');
const secondsElement = document.getElementById('seconds');
const millisecondsElement = document.getElementById('milliseconds');

function startTimer() {
    if (!running) {
        startTime = new Date().getTime();
        timerInterval = setInterval(updateTimer, 1);
        running = true;
    }
}

function updateTimer() {
    updatedTime = new Date().getTime();
    const difference = updatedTime - startTime;

    const minutes = Math.floor((difference % (1000 * 60 * 60)) / (1000 * 60));
    const seconds = Math.floor((difference % (1000 * 60)) / 1000);
    const milliseconds = difference % 1000;

    minutesElement.textContent = formatTime(minutes);
    secondsElement.textContent = formatTime(seconds);
    millisecondsElement.textContent = formatMilliseconds(milliseconds);
}

function formatTime(time) {
    return time < 10 ? '0' + time : time;
}

function formatMilliseconds(time) {
    if (time < 10) return '00' + time;
    if (time < 100) return '0' + time;
    return time;
}