$(document).ready(function () {
    $('#raceResultsTable').DataTable({
        ajax: {
            url: '/Home/GetAllRaceResults',
            dataSrc: ''
        },
        columns: [
            { data: 'race' },
            { data: 'racecourse' },
            { data: 'raceDate' },
            { data: 'raceDistance' },
            { data: 'jockey' },
            { data: 'trainer' },
            { data: 'horse' },
            { data: 'finishingPosition' },
            { data: 'distanceBeaten' },
            { data: 'timeBeaten' },
            {
                data: 'notes',
                render: function (data, type) {
                    if (data == null) {
                        return '<div class="notes-div"><textarea maxlength="140" rows="2" class="text-input"></textarea> <button class="icon-button" id="notes-save"><span class="material-symbols-outlined">save</span ></button></div>';
                    }
                    else {
                        return '<p>${data}</p>'
                    }
                }
            }

        ],
        paging: false,
        scrollCollapse: true,
        scrollY: '67vh',        
    });
});
