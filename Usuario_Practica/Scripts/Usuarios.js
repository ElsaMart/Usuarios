var Usuarios = {
    Index: function (data) {
        
        Usuarios.GetUsuarios();
    },
    GetUsuarios: function(){
        service.GetUsuarios({
            Success: function (payload) {
                $('#usuariostbl').tmpl(payload.data.Data).appendTo('#tbl-usuarios>tbody');
            },
            Error: function (error) {
                console.log(error);
            }
        });
    },
    NewUsuario: function (Id) {
        $("#divtableInfoUsuario").hide();
        $("#divFrmInfoUsuarios").show();
        $("#UserId").val("0");
        
    },
    GetUsuario: function (Id) {
        $("#divtableInfoUsuario").hide();
        $("#divFrmInfoUsuarios").show();
        service.GetUsuario({
            id: Id,
            Success: function (payload) {
                console.log(payload.data.Data);
                Usuarios.InicializaUsuario(payload.data.Data);
            },
            Error: function () {

            }
        });
    },
    DeleteUsuario: function (Id) {
        service.DeleteUsuario({
            id: Id,
            Success: function (payload) {
                $("#divtableInfoUsuario tbody").empty();
                $("#divtableInfoUsuario").show();
                $("#divFrmInfoUsuarios").hide();
                Usuarios.Index();
            }
        })
    },
    SaveUsuario: function () {
        service.SaveUsuario({
            
            Data: {
                Id: $("#UserId").val(),
                Nombre: $("#txtnombre").val(),
                Edad: $("#txtedad").val(),
                Correo: $("#txtcorreo").val()
            },
            Success: function (payload) {
                $("#UserId").val("0");
                $("#txtnombre").val("");
                $("#txtedad").val("");
                $("#txtcorreo").val("");
                $("#divtableInfoUsuario tbody").empty();
                $("#divtableInfoUsuario").show();
                $("#divFrmInfoUsuarios").hide();
                Usuarios.Index();
            },
            Error: function (error) {

            }
        })

    },
    InicializaUsuario: function (data) {
        
        $("#UserId").val(data.Id);
        $("#txtnombre").val(data.Nombre);
        $("#txtedad").val(data.Edad);
        $("#txtcorreo").val(data.Correo);

    },
    Cancela: function () {
        $("#txtnombre").val("0");
        $("#txtnombre").val("");
        $("#txtedad").val("");
        $("#txtcorreo").val("");
        $("#divtableInfoUsuario tbody").empty();
        $("#divtableInfoUsuario").show();
        $("#divFrmInfoUsuarios").hide();
        Usuarios.Index();
    }
        
};
$(document).ready(Usuarios.Index);