async function setImageUsingStreaming(imageElementId, imageStream) {
    const arrayBuffer = await imageStream.arrayBuffer();
    const blob = new Blob([arrayBuffer]);
    const urlimg = URL.createObjectURL(blob);
    document.getElementById(imageElementId).src = urlimg;
}