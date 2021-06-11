var service = {
    GetUsuarios: function (arg) {
        axios.get(endpointBaseURL + 'Usuario/GetAll',{

        })
            .then(arg.Success)
            .catch(arg.Error)
            .finally(arg.End)
    },
    SaveUsuario: function (arg) {
        axios.post(endpointBaseURL + 'Usuario/Create', arg.Data,{
            
        })
            .then(arg.Success)
            .catch(arg.Error)
            .finally(arg.End)
    },
    GetUsuario: function (arg) {
        axios.get(endpointBaseURL + 'Usuario/Get/?Id=' + arg.id, {

        })
            .then(arg.Success)
            .catch(arg.Error)
            .finally(arg.End)
    },
    DeleteUsuario: function (arg) {
        axios.get(endpointBaseURL + 'Usuario/Delete/?Id=' + arg.id, {

        })
            .then(arg.Success)
            .catch(arg.Error)
            .finally(arg.End)
    }
};