$('#listaluno').load("/ProjetoPesquisa/ListaAluno");
$('#listcoordenador').load("/ProjetoPesquisa/ListaCoordenador");
$('#listpesquisador').load("/ProjetoPesquisa/ListaPesquisador");

$('form').submit(function () {
    $('#modalAluno').modal('hide');
    $('#modalCoord').modal('hide');
    $('#modalPesq').modal('hide');
});

$('#aluno').click(function () {
    $('#modalAluno').modal('show');
    $('#modalAluno :text').val("");
    $('#modalAluno option').eq(1).removeAttr("selected");
    $('#modalAluno option').eq(0).attr("selected", "true");
});
$('#pesquisador').click(function () {
    $('#modalPesq').modal('show');
    $('#modalPesq :text, #Pid').val("");
});
$('#coordenador').click(function () {
    if (!$('#nCoord').length) {
        $('#modalCoord :submit').attr("disabled", "true");
        $('#msg-coord').css({ "opacity": "1" });
    } else {
        $('#modalCoord :submit').removeAttr("disabled");
        $('#msg-coord').css({ "opacity": "0" });
    }
    $('#modalCoord').modal('show');
    $('#modalCoord :text, #Cid').val("");
});