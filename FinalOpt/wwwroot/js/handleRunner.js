function arrangeData(data) {
    var newTableInfo = []
    data.classes.forEach(p => {
        var objs = data.timetable.filter(e => e.className == p.ClassName)
        for (let i = 0; i < 40; i++) {
            if (objs.some(e => e.hour == i)) {
                continue
            }
            else {
                objs.push({ hour: i, className: p.ClassName, teacher: '-', discipline: 'Hora libre', room: '-' })
            }
        }
        objs.sort((a, b) => a.hour - b.hour)
        newTableInfo.push(objs)
    })

    data.timetable = newTableInfo

    return data
}