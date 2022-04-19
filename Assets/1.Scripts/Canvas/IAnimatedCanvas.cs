using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAnimatedCanvas
{
    IEnumerator OnOpen();
    IEnumerator OnClose();
}
