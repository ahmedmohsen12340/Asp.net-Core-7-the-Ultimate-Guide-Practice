//start websocket

let pricex = document.querySelector(".price");
let symbolx = document.querySelector(".symbol");

const socket = new WebSocket('wss://ws.finnhub.io?token=ck2g04hr01qhd6tia670ck2g04hr01qhd6tia67g');

// Connection opened -> Subscribe
socket.addEventListener('open', function (event) {
    socket.send(JSON.stringify({ 'type': 'subscribe', 'symbol': symbolx.innerHTML }))
});

// Listen for messages
socket.addEventListener('message', function (event) {
    //console.log('Message from server ', event.data);
    if (event.data.type == "error") {
        pricex.innerHTML = event.data.msg;
        return
    }
    let x = JSON.parse(event.data)["data"][0].p;
    pricex.innerHTML = x.toFixed(2);
    
});

// Unsubscribe
 var unsubscribe = function(symbol) {
    socket.send(JSON.stringify({'type':'unsubscribe','symbol': symbol}))
}

//end websocket

