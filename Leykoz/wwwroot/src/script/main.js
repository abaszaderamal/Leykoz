document.querySelector('.closeside').addEventListener('click',()=>{
    document.querySelector('.sidebarDesktop').style.right = '100%';
    document.querySelector('.sidebarDesktop').style.visibility = 'hidden';
    document.querySelector('body').style.overflow = 'visible';
    document.querySelector('body').style.userSelect = 'all';
})
document.querySelector('.opensidebar').addEventListener('click',()=>{
    document.querySelector('body').style.overflow = 'hidden';
    document.querySelector('body').style.userSelect = 'none';
    document.querySelector('.sidebarDesktop').style.right = '0%';
    document.querySelector('.sidebarDesktop').style.visibility = 'visible';
})
