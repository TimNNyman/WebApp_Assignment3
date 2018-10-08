
function getSearchQry() {
    req = new XMLHttpRequest();
    txtInput = document.getElementById("mySearch");
    txtOutput = document.getElementById("searchReqDiv");
    url = "Search.aspx?search=" + txtInput.value;
    req.onreadystatechange = function () {
        if (req.readyState == 4 && req.status == 200) {
            txtOutput.innerHTML = req.responseText;
            setPosition();
        }
    }
    req.open("GET", url, true);
    req.send();
}

function setPosition() {
    txtInput = document.getElementById("mySearch");
    txtOutput = document.getElementById("searchReqDiv");
    var rect = txtInput.getBoundingClientRect();
    console.log(rect.top, rect.right, rect.bottom, rect.left);
    txtOutput.style.left = (rect.left) + 'px';
    txtOutput.style.top = rect.bottom + 'px';
}