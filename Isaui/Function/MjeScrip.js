function alertSi(n)
{
    //guardo el div alert
    //var con = n;
    //let diseño = document.querySelector("#divSiCCL");
    //if (con == true)
    //{
    //    diseño.classList.remove("alert-success");
    //    diseño.classList.add("alert-danger");
    //    return;
    //}
    $("#divSiCCL").show();
    //document.getElementById("#divSiCCL").style.display="none";
    //document.getElementById("#divSiCCL").style.display = "block";
}



function alertMSi()
{
    $("#divASiCCL").show();
}

function alertMNo() {
   
    $("#divANoCCL").show();
}

function modalAction() {
    $("#ventanaModalAction").modal("show");
}