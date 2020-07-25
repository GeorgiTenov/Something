var btn = document.getElementById("btn");
var xhr = new XMLHttpRequest();

function showAdverts() {
    xhr.open("get", "JsonData/Adverts.json", true);
    xhr.onreadystatechange = function () {
        if (xhr.readyState == 4 && xhr.status == 200) {
            var data = JSON.parse(xhr.responseText);
            for (var i = 0; i < data.length; i++) {
                console.log(data[i].AdvertName);
            }
        }
    }
    xhr.send();
}


btn.addEventListener("click", showAdverts);