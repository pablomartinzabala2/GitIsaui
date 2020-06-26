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

function alertNo()
{
    //esta mal el ID=#, estaba mal la palabra FUNCTION, y bootstra es un hdp, dice q le pase el alerte y no show "y mas importante el TRUE"
    $("#divNoCCL").show();
}

function alertPSi()
{
    $("#divPSiCCL").show();
}

function alertPNo() {
   
    $("#divPNoCCL").show();
}
