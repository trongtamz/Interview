
const BASE_URL = 'https://localhost:44328';

const getTodoItems = async () => {
  try {
    const list = document.getElementById("list");
    let response = await fetch(`${BASE_URL}/api/people`,{
        method: 'GET',
        mode: 'cors',
        headers: {
          accept: 'text/plain',
        },
    }); 

    if (!response.ok) {
      throw new Error(`Error! status: ${response.status}`);
    }
    const result = await response.json();
    console.log('result', result);

    // document.body.innerHTML = await response.text();
    for (let i = 0; i < result.length; i++) {
        let li = document.createElement("li");
        li.innerHTML = result[i].firstName + " " + result[i].lastName;
        list.appendChild(li);
    }
  } catch (errors) {
    console.error(errors);
    notifyMe("Error: " + errors);
  }
};
const main = async () => {
  await getTodoItems();
};

function notifyMe(message) {
    if (!window.Notification) {
        console.log('Browser does not support notifications.');
    } else {
        // check if permission is already granted
        if (Notification.permission === 'granted') {
            // show notification here
            var notify = new Notification('Hi there!', {
                body: message,
                icon: 'https://bit.ly/2DYqRrh',
            });
        } else {
            // request permission from user
            Notification.requestPermission().then(function (p) {
                if (p === 'granted') {
                    // show notification here
                    var notify = new Notification('Hi there!', {
                        body: message,
                        icon: 'https://bit.ly/2DYqRrh',
                    });
                } else {
                    console.log('User blocked notifications.');
                }
            }).catch(function (err) {
                console.error(err);
            });
        }
    }
}

main();