let sec = document.querySelector(".compDetailsComp");
let ps = document.querySelectorAll(".exploreContent ul li div p span");
try {
    ps.forEach(p => {
        let li = p.parentElement.parentElement.parentElement;
        li.addEventListener("click", async (e) => {
            //let res = await fetch(`/Stocks/GetDetails?companySymbol=${p.innerHTML}`)
            let res = await fetch(`/Stocks/Explore/${p.innerHTML}`)
            if (!res.ok)
                throw new Error("Failed to fetch")
            let response = await res.text();
            sec.innerHTML = response;
        })
    })
}
catch (e) {
    console.warn(e.message);
}