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
                render: function (data, type, row) {
                    if (data == null) {
                        return `
                <div class="notes-div">
                    <textarea maxlength="140" rows="2" class="text-input"></textarea> 
                    <button class="icon-button save-note-button" data-race-id="${row._id}">
                        <span class="material-symbols-outlined">save</span>
                    </button>
                </div>
            `;
                    } else {
                        return `<p>${data}</p>`;
                    }
                }
            }

        ],
        paging: false,
        scrollCollapse: true,
        scrollY: '67vh',        
    });


    $('#raceResultsTable tbody').on('click', '.save-note-button', function () {
        const button = $(this);
        const raceId = button.data('race-id');
        const note = button.siblings('textarea').val();

        if (!note || note.trim() === "") {
            alert("Please enter a note before saving.");
            return;
        }

        $.ajax({
            type: 'POST',
            url: '/RaceResult/SaveNote',
            data: JSON.stringify({ raceId: raceId, note: note }),
            contentType: 'application/json',
            success: function () {
                alert('Note saved successfully!');
                
                $('#raceResultsTable').DataTable().ajax.reload(null, false);
            },
            error: function () {
                alert('Error saving note.');
            }
        });
    });
});
