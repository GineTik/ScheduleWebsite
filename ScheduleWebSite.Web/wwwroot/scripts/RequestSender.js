export default function sendRequest(config) {
    return $.ajax({
        type: "POST",
        url: config.url,
        data: config.data,
        error: function (error) {
            console.log(error);
        }
    });
}